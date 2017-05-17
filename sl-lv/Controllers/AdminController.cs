using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sl_lv.Models;
using GridMvc;

namespace sl_lv.Controllers
{
    public class AdminController : Controller
    {
        private Database.DataBaseRepo db = new Database.DataBaseRepo();
        private UserViewModels model = new UserViewModels();
        private AdsViewModels ads = new AdsViewModels();

        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserControl()
        {
            if (User.IsInRole("Admin"))
            {

                model.AspNetUser = db.GetUsers();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if (User.IsInRole("Admin"))
            {
                db.DeleteUser(id);
                return RedirectToAction("UserControl", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditRole(string id)
        {
            if (User.IsInRole("Admin"))
            {
                model.AspNetUser = db.FindUser(id);
                model.AspNetRole = db.GetRoles();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditRole(string userid, string AspNetRole)
        {
            if (User.IsInRole("Admin"))
            {
                db.ChangeRole(userid, AspNetRole);
                return RedirectToAction("UserControl", "Admin");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ManageAds()
        {
            if (User.IsInRole("Admin"))
            {
                ads.Advert = db.GetAdvert();
                ads.AdvertDiscription = db.GetAdvertDiscription();
                ads.AdvertSubgroup = db.GetAdvertSubgroup();
                return View(ads);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ChangeAds(int Advert = 0)
        {
            if (User.IsInRole("Admin"))
            {
                ads.Advert = db.FindDAdvert(Advert);
                ads.AdvertDiscription = db.GetAdvertDiscription();
                ads.AdvertSubgroup = db.GetAdvertSubgroupByIDAdvert(Advert);
                return View(ads);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Deleteads(int idAdvert, int id)
        {
            if (User.IsInRole("Admin"))
            {
                db.DeleteAds(id);
                return RedirectToAction("ChangeAds", "Admin", new { Advert = idAdvert });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddAds(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Models.AdvertSubgroupModel sub = new AdvertSubgroupModel();
                sub.ID_Advert = id;
                sub.Name_RU = "";
                sub.Name_LV = "";
                sub.Name_EN = "";
                return View(sub);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddAds(AdvertSubgroupModel advertsub)
        {
            if (User.IsInRole("Admin"))
            {
                Database.AdvertSubgroup sub = new Database.AdvertSubgroup();
                sub.ID_Advert = advertsub.ID_Advert;
                sub.Name_RU = advertsub.Name_RU;
                sub.Name_LV = advertsub.Name_LV;
                sub.Name_EN = advertsub.Name_EN;
                db.ADDAds(sub);
                return RedirectToAction("ChangeAds", "Admin", new { Advert = advertsub.ID_Advert });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditAds(int id)
        {
            if (User.IsInRole("Admin"))
            {
                sl_lv.Models.AdvertSubgroupModel sub = new AdvertSubgroupModel();
                var findsub = db.FindAdvertSubgroupn(id);
                foreach (var s in findsub)
                {
                    sub.ID_AdvertSubgroup = s.ID_AdvertSubgroup;
                    sub.ID_Advert = s.ID_Advert;
                    sub.Name_RU = s.Name_RU;
                    sub.Name_LV = s.Name_LV;
                    sub.Name_EN = s.Name_EN;
                }

                return View(sub);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditAds(AdvertSubgroupModel advertsub)
        {
            if (User.IsInRole("Admin"))
            {
                Database.AdvertSubgroup sub = new Database.AdvertSubgroup();
                sub.ID_Advert = advertsub.ID_Advert;
                sub.ID_AdvertSubgroup = advertsub.ID_AdvertSubgroup;
                sub.Name_RU = advertsub.Name_RU;
                sub.Name_EN = advertsub.Name_EN;
                sub.Name_LV = advertsub.Name_LV;
                db.EditAdsSubgroupe(sub);
                return RedirectToAction("ChangeAds", "Admin", new { Advert = advertsub.ID_Advert });

            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewDiscription(int AdvertSubgroupe)
        {
            if (User.IsInRole("Admin"))
            {
                ads.Advert = db.GetAdvert();
                ads.AdvertDiscription = db.GetAdvertDiscriptionByIDAdvertSubgroupe(AdvertSubgroupe);
                ads.AdvertSubgroup = db.FindAdvertSubgroupn(AdvertSubgroupe);
                return View(ads);

            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDiscrip(int AdvertSubgroupe, int id)
        {
            if (User.IsInRole("Admin"))
            {
                db.DeleteDiscription(id);
                return RedirectToAction("ViewDiscription", "Admin", new { AdvertSubgroupe = AdvertSubgroupe });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditDiscription(int id)
        {
            if (User.IsInRole("Admin"))
            {
                sl_lv.Models.AdvertDiscriptionModel discription = new AdvertDiscriptionModel();
                var findsub = db.FindAdvertDiscriptionforEdit(id);
                foreach (var s in findsub)
                {
                    discription.ID_AdvertSubgroup = s.ID_AdvertSubgroup;
                    discription.ID_AdvertDiscription = s.ID_AdvertDiscription;
                    discription.Name_RU = s.Name_RU;
                    discription.Name_LV = s.Name_LV;
                    discription.Name_EN = s.Name_EN;
                }

                return View(discription);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditDiscription(AdvertDiscriptionModel advertdiscription)
        {
            if (User.IsInRole("Admin"))
            {
                Database.AdvertDiscription sub = new Database.AdvertDiscription();
                sub.ID_AdvertDiscription = advertdiscription.ID_AdvertDiscription;
                sub.ID_AdvertSubgroup = advertdiscription.ID_AdvertSubgroup;
                sub.Name_RU = advertdiscription.Name_RU;
                sub.Name_EN = advertdiscription.Name_EN;
                sub.Name_LV = advertdiscription.Name_LV;
                db.EditAdsDiscription(sub);
                return RedirectToAction("ViewDiscription", "Admin", new { AdvertSubgroupe = advertdiscription.ID_AdvertSubgroup });

            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddAdsDiscription(int id)
        {
            if (User.IsInRole("Admin"))
            {
                Models.AdvertDiscriptionModel sub = new AdvertDiscriptionModel();
                sub.ID_AdvertSubgroup = id;
                sub.Name_RU = "";
                sub.Name_LV = "";
                sub.Name_EN = "";
                return View(sub);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddAdsDiscription(AdvertDiscriptionModel advertdiscription)
        {
            if (User.IsInRole("Admin"))
            {
                Database.AdvertDiscription sub = new Database.AdvertDiscription();
                sub.ID_AdvertSubgroup = advertdiscription.ID_AdvertSubgroup;
                sub.Name_RU = advertdiscription.Name_RU;
                sub.Name_LV = advertdiscription.Name_LV;
                sub.Name_EN = advertdiscription.Name_EN;
                db.AddDiscription(sub);
                return RedirectToAction("ViewDiscription", "Admin", new { AdvertSubgroupe = advertdiscription.ID_AdvertSubgroup });
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddfromCSV(int id)
        {
            if (User.IsInRole("Admin"))
            {
                return View(id);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddfromCSV(HttpPostedFileBase FileUpload, int id)
        {
            if (User.IsInRole("Admin"))
            {
                if (FileUpload != null)
                {
                    if (Request.Files.Count == 1)
                    {
                        //get file
                        var postedFile = Request.Files[0];
                        if (postedFile.ContentLength > 0)
                        {
                            //read data from input stream
                            using (var csvReader = new System.IO.StreamReader(postedFile.InputStream))
                            {
                                string inputLine = "";

                                //read each line
                                while ((inputLine = csvReader.ReadLine()) != null)
                                {
                                    //get lines values
                                    string[] values = inputLine.Split(new char[] { ',' });

                                    for (int x = 2; x < values.Length; x++)
                                    {
                                        var ru = values[0];
                                        var lv = values[1];
                                        var en = values[2];

                                        Database.AdvertDiscription advertdiscription = new Database.AdvertDiscription();
                                        advertdiscription.ID_AdvertSubgroup = id;
                                        advertdiscription.Name_RU = ru;
                                        advertdiscription.Name_LV = lv;
                                        advertdiscription.Name_EN = en;

                                        db.AddDiscription(advertdiscription);
                                    }
                                }

                                csvReader.Close();
                                                              
                            }                           

                        }
                    }
                }

                return RedirectToAction("ViewDiscription", "Admin", new { AdvertSubgroupe = id });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}