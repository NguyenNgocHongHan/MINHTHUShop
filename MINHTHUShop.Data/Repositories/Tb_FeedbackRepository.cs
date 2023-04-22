using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Model.Models;

namespace MINHTHUShop.Data.Repositories
{
    public interface ITb_FeedbackRepository : IRepository<Tb_Feedback>
    {
    }

    public class Tb_FeedbackRepository : RepositoryBase<Tb_Feedback>, ITb_FeedbackRepository
    {
        public Tb_FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}