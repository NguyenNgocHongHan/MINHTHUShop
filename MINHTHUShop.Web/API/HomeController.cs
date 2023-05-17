using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Home")]
    [Authorize]
    public class HomeController : APIControllerBase
    {
        ITb_ErrorService _tb_errorService;
        public HomeController(ITb_ErrorService tb_errorService) : base(tb_errorService)
        {
            this._tb_errorService = tb_errorService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Xin chào member của cửa hàng Minh Thư!";
        }
    }
}