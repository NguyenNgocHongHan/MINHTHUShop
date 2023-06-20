using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MINHTHUShop.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        //đánh dấu mới 1 entity
        T Add(T entity);

        //đánh dấu sửa đổi 1 entity
        void Update(T entity);

        //đánh dấu xóa 1 entity
        T Delete(T entity);

        T Delete(int id);

        //xóa nhiều bảng ghi
        void DeleteMulti(Expression<Func<T, bool>> where);

        //lấy 1 entity bằng id
        T GetById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}