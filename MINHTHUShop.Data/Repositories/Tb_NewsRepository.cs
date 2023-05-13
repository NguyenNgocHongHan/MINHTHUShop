using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_NewsRepository : IRepository<Tb_News>
    {
        IEnumerable<Tb_News> GetAllByTag(string tagID, int pageIndex, int pageSize, out int totalRow);
    }

    public class Tb_NewsRepository : RepositoryBase<Tb_News>, ITb_NewsRepository
    {
        public Tb_NewsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tb_News> GetAllByTag(string tagID, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from n in DbContext.Tb_News
                        join tn in DbContext.Tb_TagNews
                        on n.NewsID equals tn.NewsID
                        where tn.TagID == tagID && n.Status == true
                        orderby n.CreateDate descending
                        select n;

            //đếm kết quả trả về
            totalRow = query.Count();

            //phân trang
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
    }
}