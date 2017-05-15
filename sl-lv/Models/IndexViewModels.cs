using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sl_lv.Models
{
    public class IndexViewModels
    {
        public List<Advert> Advert { get; set; }
        public List<AdvertSubgroup> AdvertSubgroup { get; set; }
    }
}