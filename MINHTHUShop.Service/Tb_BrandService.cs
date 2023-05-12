using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_BrandService : ITb_BrandService
    {
        private ITb_BrandRepository _tb_BrandRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_BrandService(ITb_BrandRepository tb_BrandRepository, IUnitOfWork unitOfWork)
        {
            this._tb_BrandRepository = tb_BrandRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Brand Create(Tb_Brand tb_Brand)
        {
            return _tb_BrandRepository.Add(tb_Brand);
        }

        public Tb_Brand Delete(int id)
        {
            return _tb_BrandRepository.Delete(id);
        }

        public IEnumerable<Tb_Brand> GetAll()
        {
            return _tb_BrandRepository.GetAll();
        }

        public IEnumerable<Tb_Brand> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_BrandRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_BrandRepository.GetAll();
            }
        }

        public Tb_Brand GetById(int id)
        {
            return _tb_BrandRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Brand tb_Brand)
        {
            _tb_BrandRepository.Update(tb_Brand);
        }
    }

    public interface ITb_BrandService
    {
        Tb_Brand Create(Tb_Brand tb_Brand);

        void Update(Tb_Brand tb_Brand);

        Tb_Brand Delete(int id);

        Tb_Brand GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_Brand> GetAll();

        IEnumerable<Tb_Brand> GetAll(string keywork);
    }
}