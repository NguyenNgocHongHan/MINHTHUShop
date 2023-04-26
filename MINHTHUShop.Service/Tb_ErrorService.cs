using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINHTHUShop.Service
{
    public class Tb_ErrorService : ITb_ErrorService
    {

        private ITb_ErrorRepository _tb_ErrorRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_ErrorService(ITb_ErrorRepository tb_ErrorRepository, IUnitOfWork unitOfWork)
        {
            this._tb_ErrorRepository = tb_ErrorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Error Create(Tb_Error tb_Error)
        {
            return _tb_ErrorRepository.Add(tb_Error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }

    public interface ITb_ErrorService
    {
        Tb_Error Create(Tb_Error tb_Error);

        void SaveChanges();
    }
}
