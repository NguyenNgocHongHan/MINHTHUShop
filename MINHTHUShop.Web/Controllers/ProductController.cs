﻿using AutoMapper;
using MINHTHUShop.Common;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class ProductController : Controller
    {
        ITb_ProductService _productService;
        ITb_ProductCategoryService _productCategoryService;
        ITb_BrandService _brandService;

        public ProductController(ITb_ProductService productService, ITb_ProductCategoryService productCategoryService, ITb_BrandService brandService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._brandService = brandService;
        }

        // GET: Product
        public ActionResult DetailProduct(int productId)
        {
            return View();
        }

        public ActionResult DetailCategory(int cateID, int pageIndex = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;

            var productModel = _productService.GetListProductByCateIdPaging(cateID, pageIndex, pageSize, sort, out totalRow);
            var productVM = Mapper.Map<IEnumerable<Tb_Product>, IEnumerable<ProductVM>>(productModel);

            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var productCategory = _productCategoryService.GetById(cateID);
            ViewBag.ProductCategory = Mapper.Map<Tb_ProductCategory, ProductCategoryVM>(productCategory);

            var brandModel = _brandService.GetAll();
            var brandVM = Mapper.Map<IEnumerable<Tb_Brand>, IEnumerable<BrandVM>>(brandModel);

            var pagination = new Pagination<ProductVM>()
            {
                Item = productVM,
                Brand = brandVM,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = pageIndex,
                TotalCount = totalRow,
                TotalPage = totalPage
            };

            return View(pagination);
        }
    }
}