using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sl_lv.Models
{
    public class AdsViewModels
    {
        public List<Advert> Advert { get; set; }
        public List<AdvertDiscription> AdvertDiscription { get; set; }
        public List<AdvertSubgroup> AdvertSubgroup { get; set; }
    }

    public class AdvertSubgroupModel
    {
        [Key]
        public int ID_AdvertSubgroup { get; set; }

        public int ID_Advert { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_RU { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_LV { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_EN { get; set; }

        public virtual Advert Advert { get; set; }
    }

    public class AdvertDiscriptionModel
    {
        [Key]
        public int ID_AdvertDiscription { get; set; }

        public int ID_AdvertSubgroup { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_RU { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_LV { get; set; }

        [Required]
        [StringLength(30)]
        public string Name_EN { get; set; }
    }

}