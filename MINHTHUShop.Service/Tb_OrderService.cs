using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_OrderService : ITb_OrderService
    {
        private ITb_OrderRepository _tb_OrderRepository;
        private ITb_OrderDetailRepository _tb_OrderDetailRepository;
        private ITb_UserRepository _tb_UserRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_OrderService(ITb_OrderRepository tb_OrderRepository, ITb_UserRepository tb_UserRepository, ITb_OrderDetailRepository tb_OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._tb_OrderRepository = tb_OrderRepository;
            this._tb_OrderDetailRepository = tb_OrderDetailRepository;
            this._tb_UserRepository = tb_UserRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Create(Tb_Order order, List<Tb_OrderDetail> orderDetails)
        {
            try
            {
                _tb_OrderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.OrderID;
                    _tb_OrderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void UpdateStatus(int orderID)
        {
            var order = _tb_OrderRepository.GetById(orderID);
            _tb_OrderRepository.Update(order);
        }

        public Tb_Order Delete(int id)
        {
            return _tb_OrderRepository.Delete(id);
        }

        public IEnumerable<Tb_Order> GetAll()
        {
            return _tb_OrderRepository.GetAll();
        }

        public Tb_Order GetById(int id)
        {
            return _tb_OrderRepository.GetById(id);
        }

        public void Update(Tb_Order tb_Order)
        {
            _tb_OrderRepository.Update(tb_Order);
        }

        public IEnumerable<Tb_Order> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_OrderRepository.GetMulti(x=>x.CustomerName.Contains(keywork) || x.CustomerID.Contains(keywork) /*|| _tb_UserRepository.CheckContains(y => y.Id == x.CustomerID && y.UserName.Contains(keywork))*/);
            }
            else
            {
                return _tb_OrderRepository.GetAll();
            }
        }

    }

    public interface ITb_OrderService
    {
        void Update(Tb_Order tb_Order);
        Tb_Order Delete(int id);
        Tb_Order GetById(int id);
        IEnumerable<Tb_Order> GetAll();
        IEnumerable<Tb_Order> GetAll(string keyword);
        bool Create(Tb_Order order, List<Tb_OrderDetail> orderDetails);
        void UpdateStatus(int orderID);
        void SaveChanges();
    }
}