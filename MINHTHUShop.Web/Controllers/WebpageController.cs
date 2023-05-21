using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class WebpageController : Controller
    {
        private ITb_WebpageService _webpageService;

        public WebpageController(ITb_WebpageService webpageService)
        {
            this._webpageService = webpageService;
        }

        // GET: Webpage
        public ActionResult Index(string metaTitle)
        {
            var webpage = _webpageService.GetByMetaTitle(metaTitle);
            var model = Mapper.Map<Tb_Webpage, WebpageVM>(webpage);
            return View(model);
        }
    }
}