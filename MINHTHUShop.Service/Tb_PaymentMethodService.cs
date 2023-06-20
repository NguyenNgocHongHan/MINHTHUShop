using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_PaymentMethodService : ITb_PaymentMethodService
    {
        private ITb_PaymentMethodRepository _tb_PaymentMethodRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_PaymentMethodService(ITb_PaymentMethodRepository tb_PaymentMethodRepository, IUnitOfWork unitOfWork)
        {
            this._tb_PaymentMethodRepository = tb_PaymentMethodRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_PaymentMethod Create(Tb_PaymentMethod tb_PaymentMethod)
        {
            return _tb_PaymentMethodRepository.Add(tb_PaymentMethod);
        }

        public Tb_PaymentMethod Delete(int id)
        {
            return _tb_PaymentMethodRepository.Delete(id);
        }

        public IEnumerable<Tb_PaymentMethod> GetAll()
        {
            return _tb_PaymentMethodRepository.GetAll();
        }

        public IEnumerable<Tb_PaymentMethod> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_PaymentMethodRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_PaymentMethodRepository.GetAll();
            }
        }

        public Tb_PaymentMethod GetById(int id)
        {
            return _tb_PaymentMethodRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_PaymentMethod tb_PaymentMethod)
        {
            _tb_PaymentMethodRepository.Update(tb_PaymentMethod);
        }
    }

    public interface ITb_PaymentMethodService
    {
        Tb_PaymentMethod Create(Tb_PaymentMethod tb_PaymentMethod);

        void Update(Tb_PaymentMethod tb_PaymentMethod);

        Tb_PaymentMethod Delete(int id);

        Tb_PaymentMethod GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_PaymentMethod> GetAll();

        IEnumerable<Tb_PaymentMethod> GetAll(string keywork);
    }
}