using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ProductRepository : IRepository<Tb_Product>
    {
        IEnumerable<Tb_Product> GetListProductByTag(string tagID, int pageIndex, int pageSize, string sort, out int totalRow);
    }

    public class Tb_ProductRepository : RepositoryBase<Tb_Product>, ITb_ProductRepository
    {
        public Tb_ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Tb_Product> GetListProductByTag(string tagID, int pageIndex, int pageSize, string sort, out int totalRow)
        {
            var query = from p in DbContext.Tb_Products
                        join pt in DbContext.Tb_TagProducts
                        on p.ProductID equals pt.ProductID
                        where pt.TagID == tagID
                        select p;
            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x => x.CreateDate);
                    break;
                case "lowToHigh":
                    query = query.OrderBy(x => x.PromotionPrice);
                    break;
                case "highToLow":
                    query = query.OrderByDescending(x => x.PromotionPrice);
                    break;
                default:
                    query = query.OrderBy(x => x.Name);
                    break;
            }
            totalRow = query.Count();

            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}