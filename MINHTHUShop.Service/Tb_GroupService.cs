using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Service
{
    public class Tb_GroupService : ITb_GroupService
    {
        private ITb_GroupRepository _tb_GroupRepository;
        private IUnitOfWork _unitOfWork;
        private ITb_UserGroupRepository _groupRepository;

        public Tb_GroupService(IUnitOfWork unitOfWork, ITb_UserGroupRepository groupRepository, ITb_GroupRepository appGroupRepository)
        {
            this._tb_GroupRepository = appGroupRepository;
            this._groupRepository = groupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Group Create(Tb_Group group)
        {
            if (_tb_GroupRepository.CheckContains(x => x.Name == group.Name))
                throw new NameDuplicatedException("Tên đã tồn tại!");
            return _tb_GroupRepository.Add(group);
        }

        public Tb_Group Delete(int id)
        {
            var group = this._tb_GroupRepository.GetById(id);
            return _tb_GroupRepository.Delete(group);
        }

        public IEnumerable<Tb_Group> GetAll()
        {
            return _tb_GroupRepository.GetAll();
        }

        public IEnumerable<Tb_Group> GetAll(int page, int pageSize, out int totalRow, string keyword = null)
        {
            var query = _tb_GroupRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Group group)
        {
            if (_tb_GroupRepository.CheckContains(x => x.Name == group.Name && x.GroupID != group.GroupID))
                throw new NameDuplicatedException("Tên đã tồn tại!");
            _tb_GroupRepository.Update(group);
        }

        public bool AddUserToGroups(IEnumerable<Tb_UserGroup> userGroups, string userID)
        {
            _groupRepository.DeleteMulti(x => x.UserID == userID);
            foreach (var userGroup in userGroups)
            {
                _groupRepository.Add(userGroup);
            }
            return true;
        }

        public IEnumerable<Tb_Group> GetListGroupByUserID(string userID)
        {
            return _tb_GroupRepository.GetListGroupByUserID(userID);
        }

        public IEnumerable<Tb_User> GetListUserByGroupID(int groupID)
        {
            return _tb_GroupRepository.GetListUserByGroupID(groupID);
        }
        public Tb_Group GetById(int id)
        {
            return _tb_GroupRepository.GetById(id);
        }

    }

    public interface ITb_GroupService
    {
        IEnumerable<Tb_Group> GetAll(int page, int pageSize, out int totalRow, string keyword);
        IEnumerable<Tb_Group> GetAll();
        Tb_Group GetById(int id);
        Tb_Group Create(Tb_Group group);
        void Update(Tb_Group group);
        Tb_Group Delete(int id);
        bool AddUserToGroups(IEnumerable<Tb_UserGroup> userGroups, string userID);
        IEnumerable<Tb_Group> GetListGroupByUserID(string userID);
        IEnumerable<Tb_User> GetListUserByGroupID(int groupID);
        void SaveChanges();
    }
}