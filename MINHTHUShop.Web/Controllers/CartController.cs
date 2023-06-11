using AutoMapper;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MINHTHUShop.Web.Controllers
{
    public class CartController : Controller
    {
        ITb_ProductService _productService;
        public CartController(ITb_ProductService productService)
        {
            this._productService = productService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            if (Session[CommonConstants.SessionCart] == null)
                Session[CommonConstants.SessionCart] = new List<CartVM>();
            return View();
        }
        public JsonResult GetAll()
        {
/*            if (Session[CommonConstants.SessionCart] == null)
                Session[CommonConstants.SessionCart] = new List<CartVM>();
*/            var cartSession = (List<CartVM>)Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cartSession,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int productID)
        {
            var cartSession = (List<CartVM>)Session[CommonConstants.SessionCart];
            if (cartSession == null)
            {
                cartSession = new List<CartVM>();
            }
            if (cartSession.Any(x => x.ProductID == productID))
            {
                foreach (var item in cartSession)
                {
                    if (item.ProductID == productID)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                CartVM newItem = new CartVM();
                newItem.ProductID = productID;
                var product = _productService.GetById(productID);
                newItem.Product = Mapper.Map<Tb_Product, ProductVM>(product);
                newItem.Quantity = 1;
                cartSession.Add(newItem);
            }

            Session[CommonConstants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartVM = new JavaScriptSerializer().Deserialize<List<CartVM>>(cartData);
            var cartSession = (List<CartVM>)Session[CommonConstants.SessionCart];

            foreach (var itemSession in cartSession)
            {
                foreach (var itemVM in cartVM)
                {
                    if (itemSession.ProductID == itemVM.ProductID)
                    {
                        itemSession.Quantity = itemVM.Quantity;
                    }
                }
            }

            Session[CommonConstants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<CartVM>();
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int productID)
        {
            var cartSession = (List<CartVM>)Session[CommonConstants.SessionCart];
            if (cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductID == productID);
                Session[CommonConstants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }


    }
}