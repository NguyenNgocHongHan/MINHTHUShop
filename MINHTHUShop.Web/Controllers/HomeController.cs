using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class HomeController : Controller
    {
        ITb_ProductCategoryService _productCategoryService;
        /*ITb_ProductService _productService;*/
        ICommonService _commonService;
        public HomeController(ITb_ProductCategoryService productCategoryService/*, ITb_ProductService productService*/, ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            /*_productService = productService;*/
        }

        public ActionResult Index()
        {
            return View();
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

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var listfooterVM = Mapper.Map<Tb_Footer, FooterVM>(footerModel);
            return PartialView(listfooterVM);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryVM = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(model);
            return PartialView(listProductCategoryVM);
        }
    }
}