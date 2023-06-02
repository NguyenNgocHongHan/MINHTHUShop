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
        ITb_ProductService _productService;
        ITb_BrandService _brandService;
        ICommonService _commonService;
        public HomeController(ITb_ProductCategoryService productCategoryService, ITb_ProductService productService, ITb_BrandService brandService, ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
            _brandService = brandService;
        }

        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            var bannerModel = _commonService.GetBanners();
            var bannerView = Mapper.Map<IEnumerable<Tb_Banner>, IEnumerable<BannerVM>>(bannerModel);
            var homeVM = new HomeVM();
            homeVM.Banners = bannerView;

            var lastestProductModel = _productService.GetLastest(3);
            var lastestProductVM = Mapper.Map<IEnumerable<Tb_Product>, IEnumerable<ProductVM>>(lastestProductModel);
            homeVM.LastestProducts = lastestProductVM;

            var productCategoryModel = _productCategoryService.GetAll();
            var productCategoryVM = Mapper.Map<IEnumerable<Tb_ProductCategory>, IEnumerable<ProductCategoryVM>>(productCategoryModel);
            homeVM.ProductCategories = productCategoryVM;

            var productsByCategoryModel = _productService.GetAll();
            var productsByCategoryVM = Mapper.Map<IEnumerable<Tb_Product>, IEnumerable<ProductVM>>(productsByCategoryModel);
            homeVM.ProductsByCategory = productsByCategoryVM;

            var brandModel = _brandService.GetAll();
            var brandVM = Mapper.Map<IEnumerable<Tb_Brand>, IEnumerable<BrandVM>>(brandModel);
            homeVM.Brand = brandVM;

            return View(homeVM);
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