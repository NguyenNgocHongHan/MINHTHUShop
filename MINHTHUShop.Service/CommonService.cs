using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Service
{
    public interface ICommonService
    {
        Tb_Footer GetFooter();

        /*IEnumerable<Slide> GetSlides();*/
    }

    public class CommonService : ICommonService
    {
        private ITb_FooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        /*ISlideRepository _slideRepository;*/

        public CommonService(ITb_FooterRepository footerRepository, IUnitOfWork unitOfWork/*, ISlideRepository slideRepository*/)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            /*_slideRepository = slideRepository;*/
        }

        public Tb_Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.FooterID == CommonConstants.DefaultFooterId);
        }

        /*public IEnumerable<Slide> GetSlides()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }*/
    }
}