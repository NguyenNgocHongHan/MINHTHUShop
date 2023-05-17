using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public interface ICommonService
    {
        Tb_Footer GetFooter();

        IEnumerable<Tb_Banner> GetBanners();
    }

    public class CommonService : ICommonService
    {
        private ITb_FooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        ITb_BannerRepository _bannerRepository;

        public CommonService(ITb_FooterRepository footerRepository, IUnitOfWork unitOfWork, ITb_BannerRepository bannerRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _bannerRepository = bannerRepository;
        }

        public Tb_Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.FooterID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Tb_Banner> GetBanners()
        {
            return _bannerRepository.GetMulti(x => x.Status);
        }
    }
}