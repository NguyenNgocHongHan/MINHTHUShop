using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using System.Web.Http;

namespace MINHTHUShop.Web.API
{
    [RoutePrefix("api/Home")]
    [Authorize]
    public class HomeController : APIControllerBase
    {
        private ITb_ErrorService _tb_errorService;

        public HomeController(ITb_ErrorService tb_errorService) : base(tb_errorService)
        {
            this._tb_errorService = tb_errorService;
        }

        [HttpGet]
        [Authorize(Roles = "Login")]
        [Route("GetHome")]
        public string GetHome()
        {
            return "Chào thành viên của MINH THƯ Shop!";
        }
    }
}