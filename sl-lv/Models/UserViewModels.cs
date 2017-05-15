using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace sl_lv.Models
{
    public class UserViewModels
    {
        public List<AspNetUser> AspNetUser { get; set; }
        public List<AspNetRole> AspNetRole { get; set; }
        public List<AspNetUserClaim> AspNetUserClaim { get; set; }
        public List<AspNetUserLogin> AspNetUserLogin { get; set; }
    }
}