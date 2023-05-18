using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult DetailProduct(int productId)
        {
            return View();
        }

        public ActionResult DetailCategory(int cateId)
        {
            return View();
        }
    }
}