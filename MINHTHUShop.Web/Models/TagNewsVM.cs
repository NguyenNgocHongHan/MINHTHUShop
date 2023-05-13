using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINHTHUShop.Web.Models
{
    public class TagNewsVM
    {
        public int NewsID { get; set; }
        public string TagID { get; set; }

        public virtual NewsVM NewsVM { get; set; }
        public virtual TagVM TagVM { get; set; }
    }
}