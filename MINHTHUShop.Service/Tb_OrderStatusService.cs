using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_OrderStatusService : ITb_OrderStatusService
    {
        private ITb_OrderStatusRepository _tb_OrderStatusRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_OrderStatusService(ITb_OrderStatusRepository tb_OrderStatusRepository, IUnitOfWork unitOfWork)
        {
            this._tb_OrderStatusRepository = tb_OrderStatusRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_OrderStatus Create(Tb_OrderStatus tb_OrderStatus)
        {
            return _tb_OrderStatusRepository.Add(tb_OrderStatus);
        }

        public Tb_OrderStatus Delete(int id)
        {
            return _tb_OrderStatusRepository.Delete(id);
        }

        public IEnumerable<Tb_OrderStatus> GetAll()
        {
            return _tb_OrderStatusRepository.GetAll();
        }

        public IEnumerable<Tb_OrderStatus> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_OrderStatusRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_OrderStatusRepository.GetAll();
            }
        }

        public Tb_OrderStatus GetById(int id)
        {
            return _tb_OrderStatusRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_OrderStatus tb_OrderStatus)
        {
            _tb_OrderStatusRepository.Update(tb_OrderStatus);
        }
    }

    public interface ITb_OrderStatusService
    {
        Tb_OrderStatus Create(Tb_OrderStatus tb_OrderStatus);

        void Update(Tb_OrderStatus tb_OrderStatus);

        Tb_OrderStatus Delete(int id);

        Tb_OrderStatus GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_OrderStatus> GetAll();

        IEnumerable<Tb_OrderStatus> GetAll(string keywork);
    }
}