using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_ShippingMethodService : ITb_ShippingMethodService
    {
        private ITb_ShippingMethodRepository _tb_ShippingMethodRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_ShippingMethodService(ITb_ShippingMethodRepository tb_ShippingMethodRepository, IUnitOfWork unitOfWork)
        {
            this._tb_ShippingMethodRepository = tb_ShippingMethodRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_ShippingMethod Create(Tb_ShippingMethod tb_ShippingMethod)
        {
            return _tb_ShippingMethodRepository.Add(tb_ShippingMethod);
        }

        public Tb_ShippingMethod Delete(int id)
        {
            return _tb_ShippingMethodRepository.Delete(id);
        }

        public IEnumerable<Tb_ShippingMethod> GetAll()
        {
            return _tb_ShippingMethodRepository.GetAll();
        }

        public IEnumerable<Tb_ShippingMethod> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_ShippingMethodRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_ShippingMethodRepository.GetAll();
            }
        }

        public Tb_ShippingMethod GetById(int id)
        {
            return _tb_ShippingMethodRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_ShippingMethod tb_ShippingMethod)
        {
            _tb_ShippingMethodRepository.Update(tb_ShippingMethod);
        }
    }

    public interface ITb_ShippingMethodService
    {
        Tb_ShippingMethod Create(Tb_ShippingMethod tb_ShippingMethod);

        void Update(Tb_ShippingMethod tb_ShippingMethod);

        Tb_ShippingMethod Delete(int id);

        Tb_ShippingMethod GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_ShippingMethod> GetAll();

        IEnumerable<Tb_ShippingMethod> GetAll(string keywork);
    }
}