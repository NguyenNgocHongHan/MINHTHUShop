using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public interface ITb_WebpageService
    {
        Tb_Webpage GetByMetaTitle(string metaTitle);
        Tb_Webpage Create(Tb_Webpage tb_Webpage);
        void Update(Tb_Webpage tb_Webpage);
        Tb_Webpage Delete(int id);
        Tb_Webpage GetById(int id);
        void SaveChanges();
        IEnumerable<Tb_Webpage> GetAll();
        IEnumerable<Tb_Webpage> GetAll(string keywork);
        IEnumerable<Tb_Webpage> GetListWebpage(string keywork);

    }

    public class Tb_WebpageService : ITb_WebpageService
    {
        private ITb_WebpageRepository _tb_WebpageRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_WebpageService(ITb_WebpageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this._tb_WebpageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Webpage Create(Tb_Webpage tb_Webpage)
        {
            var webpage = _tb_WebpageRepository.Add(tb_Webpage);
            _unitOfWork.Commit();
            return webpage;
        }

        public Tb_Webpage Delete(int id)
        {
            return _tb_WebpageRepository.Delete(id);
        }

        public IEnumerable<Tb_Webpage> GetAll()
        {
            return _tb_WebpageRepository.GetAll();
        }

        public IEnumerable<Tb_Webpage> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
            {
                return _tb_WebpageRepository.GetMulti(x => x.Name.Contains(keywork) || x.Description.Contains(keywork));
            }
            else
            {
                return _tb_WebpageRepository.GetAll();
            }
        }

        public Tb_Webpage GetById(int id)
        {
            return _tb_WebpageRepository.GetById(id);
        }

        public Tb_Webpage GetByMetaTitle(string metaTitle)
        {
            return _tb_WebpageRepository.GetSingleByCondition(x => x.MetaTitle == metaTitle && x.Status == true);
        }

        public IEnumerable<Tb_Webpage> GetListWebpage(string keywork)
        {
            IEnumerable<Tb_Webpage> query;
            if (!string.IsNullOrEmpty(keywork))
            {
                query = _tb_WebpageRepository.GetMulti(x => x.Name.Contains(keywork));
            }
            else
            {
                query = _tb_WebpageRepository.GetAll();
            }
            return query;
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Webpage tb_Webpage)
        {
            _tb_WebpageRepository.Update(tb_Webpage);
        }
    }
}