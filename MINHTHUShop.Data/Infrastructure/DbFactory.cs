namespace MINHTHUShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MINHTHUShopDbContext dbContext;

        public MINHTHUShopDbContext Init()
        {
            return dbContext ?? (dbContext = new MINHTHUShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}