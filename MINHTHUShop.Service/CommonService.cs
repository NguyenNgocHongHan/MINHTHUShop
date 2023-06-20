using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class CommonService : ICommonService
    {
        private IUnitOfWork _unitOfWork;
        ITb_BannerRepository _bannerRepository;

        public CommonService(IUnitOfWork unitOfWork, ITb_BannerRepository bannerRepository)
        {
            _unitOfWork = unitOfWork;
            _bannerRepository = bannerRepository;
        }

        public IEnumerable<Tb_Banner> GetBanners()
        {
            return _bannerRepository.GetMulti(x => x.Status);
        }

    }


    public interface ICommonService
    {
        IEnumerable<Tb_Banner> GetBanners();

    }
}