using System;

namespace MINHTHUShop.Data.Infrastructure
{ 
    //phương thức tự động hủy
    public class Disposable : IDisposable
    {
        //để phát hiện các lệnh gọi dư thừa
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        //triển khai các Dispose pattern mà người dùng có thể gọi
        public void Dispose()
        {
            //loại bỏ các nguồn tài nguyên không được quản lý
            Dispose(true);  
            GC.SuppressFinalize(this);
        }

        //triển khai Dispose pattern được bảo vệ
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                //xử lý trạng thái, đối tượng được quản lý
                DisposeCore();
            }

            //giải phóng tài nguyên, đối tượng không được quản lý và ghi đè
            isDisposed = true;
        }

        //ghi đè để loại bỏ các đối tượng tùy chỉnh
        protected virtual void DisposeCore()
        {
        }
    }
}