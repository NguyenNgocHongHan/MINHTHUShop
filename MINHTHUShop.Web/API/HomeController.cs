using AutoMapper;
using MINHTHUShop.Model.Models;
using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using MINHTHUShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Home")]
    [Authorize]
    public class HomeController : APIControllerBase
    {
        private ITb_ErrorService _tb_errorService;

        public HomeController(ITb_ErrorService tb_errorService, Tb_AboutService tb_AboutService) : base(tb_errorService)
        {
            this._tb_errorService = tb_errorService;
        }

        /*[HttpGet]
        [Route("TestMethod")]
        [AllowAnonymous]
        public string TestMethod()
        {
            return "Chào thành viên của MINH THƯ Shop!";
        }*/
    }
}