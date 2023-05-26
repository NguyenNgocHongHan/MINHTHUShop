using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MINHTHUShop.Data.Repositories;

namespace MINHTHUShop.Service
{
    public class Tb_CustomerService : ITb_CustomerService
    {
        private ITb_CustomerRepository _tb_CustomerRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_CustomerService(ITb_CustomerRepository tb_CustomerRepository, IUnitOfWork unitOfWork)
        {
            this._tb_CustomerRepository = tb_CustomerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Customer Create(Tb_Customer tb_Customer)
        {
            var customer = _tb_CustomerRepository.Add(tb_Customer);
            _unitOfWork.Commit();
            return customer;
        }

        public Tb_Customer Delete(int id)
        {
            return _tb_CustomerRepository.Delete(id);
        }

        public IEnumerable<Tb_Customer> GetAll()
        {
            return _tb_CustomerRepository.GetAll();
        }

        public IEnumerable<Tb_Customer> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_CustomerRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_CustomerRepository.GetAll();
            }
        }

        public Tb_Customer GetById(int id)
        {
            return _tb_CustomerRepository.GetById(id);
        }

        public IEnumerable<Tb_Customer> GetLastest(int top)
        {
            return _tb_CustomerRepository.GetMulti(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(top);
        }

        public IEnumerable<Tb_Customer> GetListCustomer(string keywork)
        {
            IEnumerable<Tb_Customer> query;
            if (!string.IsNullOrEmpty(keywork))
            {
                query = _tb_CustomerRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                query = _tb_CustomerRepository.GetAll();
            }
            return query;
        }

        public IEnumerable<string> GetListCustomerByName(string name)
        {
            return _tb_CustomerRepository.GetMulti(x => x.Status == true && x.Name.Contains(name)).Select(y => y.Name);
        }

        public Tb_Customer GetByEmail(string email)
        {
            return _tb_CustomerRepository.GetSingleByCondition(x => x.Email == email);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Tb_Customer> Search(string keywork, int pageIndex, int pageSize, out int totalRow)
        {
            var query = _tb_CustomerRepository.GetMulti(x => x.Status == true && x.Name.Contains(keywork));
            totalRow = query.Count();

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public void Update(Tb_Customer tb_Customer)
        {
            _tb_CustomerRepository.Update(tb_Customer);

        }
    }

    public interface ITb_CustomerService
    {
        Tb_Customer Create(Tb_Customer tb_Customer);

        void Update(Tb_Customer tb_Customer);

        Tb_Customer Delete(int id);

        Tb_Customer GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_Customer> GetAll();

        IEnumerable<Tb_Customer> GetAll(string keywork);

        IEnumerable<Tb_Customer> GetLastest(int top);

       Tb_Customer GetByEmail(string email);

        IEnumerable<Tb_Customer> Search(string keywork, int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_Customer> GetListCustomer(string keywork);

        IEnumerable<string> GetListCustomerByName(string name);

    }
}