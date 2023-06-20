using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_BannerService : ITb_BannerService
    {
        private ITb_BannerRepository _tb_BannerRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_BannerService(ITb_BannerRepository tb_BannerRepository, IUnitOfWork unitOfWork)
        {
            this._tb_BannerRepository = tb_BannerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Banner Create(Tb_Banner tb_Banner)
        {
            return _tb_BannerRepository.Add(tb_Banner);
        }

        public Tb_Banner Delete(int id)
        {
            return _tb_BannerRepository.Delete(id);
        }

        public IEnumerable<Tb_Banner> GetAll()
        {
            return _tb_BannerRepository.GetAll();
        }

        public IEnumerable<Tb_Banner> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_BannerRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_BannerRepository.GetAll();
            }
        }

        public Tb_Banner GetById(int id)
        {
            return _tb_BannerRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Banner tb_Banner)
        {
            _tb_BannerRepository.Update(tb_Banner);
        }
    }

    public interface ITb_BannerService
    {
        Tb_Banner Create(Tb_Banner tb_Banner);

        void Update(Tb_Banner tb_Banner);

        Tb_Banner Delete(int id);

        Tb_Banner GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_Banner> GetAll();

        IEnumerable<Tb_Banner> GetAll(string keywork);
    }
}