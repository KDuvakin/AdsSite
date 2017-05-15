using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataBaseRepo
    {
        private DataRepo DB = new DataRepo();

        public List<Advert> GetAdvert()
        {
            return DB.Adverts.ToList();
        }

        public List<Advert> FindDAdvert(int id)
        {
            var advert = from a in DB.Adverts where a.ID_Advert == id select a;
            return advert.ToList();
        }

        public List<AdvertSubgroup> GetAdvertSubgroup()
        {

            return DB.AdvertSubgroups.ToList();
        }

        public List<AdvertSubgroup> GetAdvertSubgroupByIDAdvert(int id)
        {
            var advert = from a in DB.AdvertSubgroups where a.ID_Advert == id select a;
            return advert.ToList();
        }

        public List<AdvertDiscription> GetAdvertDiscription()
        {

            return DB.AdvertDiscriptions.ToList();
        }

        public List<AdvertDiscription> FindAdvertDiscription(int id)
        {
            var advert = from a in DB.AdvertDiscriptions where a.ID_AdvertSubgroup == id select a;

            return advert.ToList();
        }

        public List<AdvertDiscription> FindAdvertDiscriptionforEdit(int id)
        {
            var advert = from a in DB.AdvertDiscriptions where a.ID_AdvertDiscription == id select a;

            return advert.ToList();
        }

        public List<AdvertSubgroup> FindAdvertSubgroupn(int id)
        {
            var advert = from a in DB.AdvertSubgroups where a.ID_AdvertSubgroup == id select a;

            return advert.ToList();
        }

        public List<AspNetUser> GetUsers()
        {
            return DB.AspNetUsers.ToList();
        }

        public void DeleteUser(string id)
        {
            AspNetUser user = new AspNetUser() { Id = id };

            DB.AspNetUsers.Attach(user);
            DB.AspNetUsers.Remove(user);
            DB.SaveChanges();

        }

        public List<AspNetUser> FindUser(string id)
        {
            var user = from a in DB.AspNetUsers where a.Id == id select a;
            return user.ToList();
        }

        public List<AspNetRole> GetRoles()
        {
            return DB.AspNetRoles.ToList();
        }

        public void ChangeRole(string userid, string roleid)
        {
            if (userid != null && roleid != null)
            {
                var user = DB.AspNetUsers.Find(userid);
                var role = DB.AspNetRoles.Find(roleid);
                try
                {


                    if (user.AspNetRoles != null)
                    {
                        foreach (var r in user.AspNetRoles)
                        {
                            user.AspNetRoles.Remove(r);
                            break;
                        }
                        user.AspNetRoles.Add(role);

                        DB.SaveChanges();

                    }
                    else
                    {
                        user.AspNetRoles.Add(role);
                        DB.SaveChanges();
                    }


                }
                catch (Exception e)
                {
                    e.ToString();

                }
            }


        }

        public void DeleteAds(int id)
        {
            AdvertSubgroup ads = new AdvertSubgroup() { ID_AdvertSubgroup = id };

            DB.AdvertSubgroups.Attach(ads);
            DB.AdvertSubgroups.Remove(ads);
            DB.SaveChanges();
        }

        public void ADDAds(AdvertSubgroup advertsubgroup)
        {
            DB.AdvertSubgroups.Add(advertsubgroup);
            DB.SaveChanges();
        }

        public void EditAdsSubgroupe(AdvertSubgroup advertsubgroup)
        {
            var ads = DB.AdvertSubgroups.Find(advertsubgroup.ID_AdvertSubgroup); 
            ads.ID_Advert = advertsubgroup.ID_Advert;
            ads.ID_AdvertSubgroup = advertsubgroup.ID_AdvertSubgroup;
            ads.Name_RU = advertsubgroup.Name_RU;
            ads.Name_LV = advertsubgroup.Name_LV;
            ads.Name_EN = advertsubgroup.Name_EN;
            DB.SaveChanges();
        }

        public List<AdvertDiscription> GetAdvertDiscriptionByIDAdvertSubgroupe(int id)
        {
            var advert = from a in DB.AdvertDiscriptions where a.ID_AdvertSubgroup == id select a;
            return advert.ToList();
        }

        public void DeleteDiscription(int id)
        {
            AdvertDiscription ads = new AdvertDiscription() { ID_AdvertDiscription = id };

            DB.AdvertDiscriptions.Attach(ads);
            DB.AdvertDiscriptions.Remove(ads);
            DB.SaveChanges();
        }

        public void EditAdsDiscription(AdvertDiscription advertdiscription)
        {
            var ads = DB.AdvertDiscriptions.Find(advertdiscription.ID_AdvertDiscription);
            ads.ID_AdvertDiscription = advertdiscription.ID_AdvertDiscription;
            ads.ID_AdvertSubgroup = advertdiscription.ID_AdvertSubgroup;
            ads.Name_RU = advertdiscription.Name_RU;
            ads.Name_LV = advertdiscription.Name_LV;
            ads.Name_EN = advertdiscription.Name_EN;
            DB.SaveChanges();
        }

        public void AddDiscription(AdvertDiscription adddiscription)
        {
            DB.AdvertDiscriptions.Add(adddiscription);
            DB.SaveChanges();
        }
    }
}
