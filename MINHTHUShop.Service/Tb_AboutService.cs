using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_AboutService : ITb_AboutService
    {
        private ITb_AboutRepository _tb_AboutRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_AboutService(ITb_AboutRepository tb_AboutRepository, IUnitOfWork unitOfWork)
        {
            this._tb_AboutRepository = tb_AboutRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_About Create(Tb_About tb_About)
        {
            return _tb_AboutRepository.Add(tb_About);
        }

        public Tb_About Delete(int id)
        {
            return _tb_AboutRepository.Delete(id);
        }

        public IEnumerable<Tb_About> GetAll()
        {
            return _tb_AboutRepository.GetAll();
        }

        public IEnumerable<Tb_About> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_AboutRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                return _tb_AboutRepository.GetAll();
            }
        }

        public Tb_About GetById(int id)
        {
            return _tb_AboutRepository.GetById(id);
        }

        public Tb_About GetDefaultAbout()
        {
            return _tb_AboutRepository.GetSingleByCondition(x => x.Status);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_About tb_About)
        {
            _tb_AboutRepository.Update(tb_About);
        }
    }

    public interface ITb_AboutService
    {
        Tb_About GetDefaultAbout();

        Tb_About Create(Tb_About tb_About);

        void Update(Tb_About tb_About);

        Tb_About Delete(int id);

        Tb_About GetById(int id);

        void SaveChanges();

        IEnumerable<Tb_About> GetAll();

        IEnumerable<Tb_About> GetAll(string keywork);

    }
}