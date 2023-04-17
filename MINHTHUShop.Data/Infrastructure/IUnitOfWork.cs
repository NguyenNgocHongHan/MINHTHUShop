namespace MINHTHUShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        //lưu trữ các thay đổi vào cơ sở dữ liệu
        void Commit();
    }
}