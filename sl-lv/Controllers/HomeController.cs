using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sl_lv.Helpers;
using sl_lv.Models;

namespace sl_lv.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SetCulture(string id)
        {
            id = CultureHelper.GetImplementedCulture(id);
            HttpCookie cookie = Request.Cookies["_culture"];
            RouteData.Values["lang"] = id;

            if (cookie != null)
                cookie.Value = id;
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = id;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }


        private Database.DataBaseRepo DB = new Database.DataBaseRepo();
        public ActionResult Index()
        {
            IndexViewModels model = new IndexViewModels();
            model.Advert = DB.GetAdvert();
            model.AdvertSubgroup = DB.GetAdvertSubgroup();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Ads(int id)
        {
            AdsViewModels model = new AdsViewModels();
            model.AdvertDiscription = DB.FindAdvertDiscription(id);
            model.AdvertSubgroup = DB.FindAdvertSubgroupn(id);
            return View(model);

        }

        public ActionResult Advertisement(int id)
        {
            AdsViewModels model = new AdsViewModels();
            model.AdvertDiscription = DB.FindAdvertDiscription(id);
            model.AdvertSubgroup = DB.FindAdvertSubgroupn(id);
            return View(model);
        }

        [Authorize]
        public ActionResult AddNewAds()
        {
            AdsViewModels model = new AdsViewModels();
            model.Advert = DB.GetAdvert();
            model.AdvertDiscription = DB.GetAdvertDiscription();
            model.AdvertSubgroup = DB.GetAdvertSubgroup();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddAdsSub(int Advertid)
        {
            AdsViewModels model = new AdsViewModels();
            model.Advert = DB.GetAdvert();
            model.AdvertDiscription = DB.GetAdvertDiscription();
            model.AdvertSubgroup = DB.GetAdvertSubgroupByIDAdvert(Advertid);
            ViewBag.advertid = Advertid;
            return View(model);
        }

    }

}