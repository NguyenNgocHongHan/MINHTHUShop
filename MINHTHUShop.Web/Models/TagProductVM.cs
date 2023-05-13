using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINHTHUShop.Web.Models
{
    public class TagProductVM
    {
        public int ProductID { get; set; }
        public string TagID { get; set; }

        public virtual ProductVM ProductVM { get; set; }
        public virtual TagVM TagVM { get; set; }
    }
}