using System;

namespace MINHTHUShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        //để tạo ra một đối tượng của lớp MINHTHUShopDbContext để truy cập cơ sở dữ liệu
        MINHTHUShopDbContext Init();
    }
}