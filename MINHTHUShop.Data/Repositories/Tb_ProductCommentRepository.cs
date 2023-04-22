using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_ProductCommentRepository : IRepository<Tb_ProductComment>
    {
    }

    public class Tb_ProductCommentRepository : RepositoryBase<Tb_ProductComment>, ITb_ProductCommentRepository
    {
        public Tb_ProductCommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}