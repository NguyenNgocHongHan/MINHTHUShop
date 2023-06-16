using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITb_ProductCategoryService _productCategoryService;
        private ITb_ProductService _productService;
        private ITb_BrandService _brandService;
        private ICommonService _commonService;

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

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}