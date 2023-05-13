using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;

namespace MINHTHUShop.Service
{
    public class Tb_NewsService : ITb_NewsService
    {
        private ITb_NewsRepository _tb_NewsRepository;
        private ITb_TagRepository _tb_TagRepository;
        private ITb_TagNewsRepository _tb_TagNewsRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_NewsService(ITb_NewsRepository tb_NewsRepository, ITb_TagRepository tb_TagRepository, ITb_TagNewsRepository tb_TagNewsRepository, IUnitOfWork unitOfWork)
        {
            this._tb_NewsRepository = tb_NewsRepository;
            this._tb_TagRepository = tb_TagRepository;
            this._tb_TagNewsRepository = tb_TagNewsRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_News Create(Tb_News tb_News)
        {
            var news = _tb_NewsRepository.Add(tb_News);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(tb_News.Tag))
            {
                string[] tags = tb_News.Tag.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tb_TagRepository.Count(x => x.TagID == tagId) == 0)
                    {
                        Tb_Tag tag = new Tb_Tag();
                        tag.TagID = tagId;
                        tag.Name = tags[i].ToUpper();
                        tag.Type = CommonConstants.NewsTag;
                        _tb_TagRepository.Add(tag);
                    }

                    Tb_TagNews newsTag = new Tb_TagNews();
                    newsTag.NewsID = tb_News.NewsID;
                    newsTag.TagID = tagId;
                    _tb_TagNewsRepository.Add(newsTag);
                }
            }
            return news;
        }

        public Tb_News Delete(int id)
        {
            return _tb_NewsRepository.Delete(id);
        }

        public IEnumerable<Tb_News> GetAll()
        {
            return _tb_NewsRepository.GetAll(new string[] { "Tb_NewsCategory" });
        }

        public IEnumerable<Tb_News> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetMultiPaging(x => x.Status == true && x.NewsCateID == cateID, out totalRow, pageIndex, pageSize, new string[] { "Tb_NewsCategory" });
        }

        //lấy ra tất cả các bài viết theo thẻ tag
        public IEnumerable<Tb_News> GetAllByTagPaging(string tagID, int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetAllByTag(tagID, pageIndex, pageSize, out totalRow);
        }

        public IEnumerable<Tb_News> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _tb_NewsRepository.GetMultiPaging(x => x.Status == true, out totalRow, pageIndex, pageSize);
        }

        public Tb_News GetById(int id)
        {
            return _tb_NewsRepository.GetById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_News tb_News)
        {
            _tb_NewsRepository.Update(tb_News);

            if (!string.IsNullOrEmpty(tb_News.Tag))
            {
                string[] tags = tb_News.Tag.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tb_TagRepository.Count(x => x.TagID == tagId) == 0)
                    {
                        Tb_Tag tag = new Tb_Tag();
                        tag.TagID = tagId;
                        tag.Name = tags[i].ToUpper();
                        tag.Type = CommonConstants.NewsTag;
                        _tb_TagRepository.Add(tag);
                    }

                    _tb_TagNewsRepository.DeleteMulti(x => x.NewsID == tb_News.NewsID);
                    Tb_TagNews newsTag = new Tb_TagNews();
                    newsTag.NewsID = tb_News.NewsID;
                    newsTag.TagID = tagId;
                    _tb_TagNewsRepository.Add(newsTag);
                }
            }
        }
    }

    public interface ITb_NewsService
    {
        Tb_News Create(Tb_News tb_News);

        void Update(Tb_News tb_News);

        Tb_News Delete(int id);

        void SaveChanges();

        Tb_News GetById(int id);

        IEnumerable<Tb_News> GetAll();

        IEnumerable<Tb_News> GetAllPaging(int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_News> GetAllByCategoryPaging(int cateID, int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Tb_News> GetAllByTagPaging(string tagID, int pageIndex, int pageSize, out int totalRow);
    }
}