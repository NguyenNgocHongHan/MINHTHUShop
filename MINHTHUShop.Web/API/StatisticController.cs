using MINHTHUShop.Service;
using MINHTHUShop.Web.Infrastructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MINHTHUShop.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Statistic")]
    public class StatisticController : APIControllerBase
    {
        private IStatisticService _statisticService;

        public StatisticController(ITb_ErrorService errorService, IStatisticService statisticService) : base(errorService)
        {
            _statisticService = statisticService;
        }

        [Route("GetRevenues")]
        [HttpGet]
        [Authorize(Roles = "ViewStatistic")]
        public HttpResponseMessage GetRevenueStatistic(HttpRequestMessage request, string fromDate = "01/01/2023", string toDate = "12/31/2023")
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _statisticService.GetRevenueStatistics(fromDate, toDate);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }
    }
}