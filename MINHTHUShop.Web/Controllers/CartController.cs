using AutoMapper;
using Microsoft.AspNet.Identity;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.App_Start;
using MINHTHUShop.Web.Infrastructure.Extensions;
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
        ITb_OrderService _orderService;
        ITb_PaymentMethodService _paymentMethodService;
        ITb_ShippingMethodService _shippingMethodService;

        private ApplicationUserManager _userManager;

        public CartController(ITb_ProductService productService, ITb_OrderService orderService, ITb_PaymentMethodService paymentMethodService, ITb_ShippingMethodService shippingMethodService, ApplicationUserManager userManager)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._paymentMethodService = paymentMethodService;
            this._shippingMethodService = shippingMethodService;
            this._userManager = userManager;
        }
        // GET: Cart
        public ActionResult Index()
        {
            if (Session[CommonConstants.SessionCart] == null)
                Session[CommonConstants.SessionCart] = new List<CartVM>();

            var orderVM = new OrderVM();
            var paymentMethod = _paymentMethodService.GetAll();
            var paymentMethodVM = Mapper.Map<IEnumerable<Tb_PaymentMethod>, IEnumerable<PaymentMethodVM>>(paymentMethod);
            orderVM.PaymentMethodVMs = paymentMethodVM;

            var shippingMethod = _shippingMethodService.GetAll();
            var shippingMethodVM = Mapper.Map<IEnumerable<Tb_ShippingMethod>, IEnumerable<ShippingMethodVM>>(shippingMethod);
            orderVM.ShippingMethodVMs = shippingMethodVM;

            return View(orderVM);
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

        public JsonResult GetUser()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        public JsonResult CreateOrder(string orderVM)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderVM>(orderVM);
            var orderNew = new Tb_Order();

            orderNew.UpdateOrder(order);
            orderNew.CustomerID = User.Identity.GetUserId();

            var cart = (List<CartVM>)Session[CommonConstants.SessionCart];
            List<Tb_OrderDetail> orderDetails = new List<Tb_OrderDetail>();

            foreach (var item in cart)
            {
                var detail = new Tb_OrderDetail();
                detail.ProductID = item.ProductID;
                detail.Quantity = item.Quantity;
                orderDetails.Add(detail);
            }

            _orderService.Create(orderNew, orderDetails);

            return Json(new
            {
                status = true
            });
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