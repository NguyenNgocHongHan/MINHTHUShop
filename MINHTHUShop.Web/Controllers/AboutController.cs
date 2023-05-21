using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Models;
using System.Web.Mvc;

namespace MINHTHUShop.Web.Controllers
{
    public class AboutController : Controller
    {
        ITb_AboutService _tb_AboutService;
        public AboutController(ITb_AboutService tb_AboutService)
        {
            this._tb_AboutService = tb_AboutService;
        }
        // GET: Contact
        public ActionResult Index()
        {
            var model = _tb_AboutService.GetDefaultAbout();
            var contactViewModel = Mapper.Map<Tb_About, AboutVM>(model);
            return View(contactViewModel);
        }
    }
}