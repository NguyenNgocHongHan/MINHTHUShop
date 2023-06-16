using MINHTHUShop.Common;
using MINHTHUShop.Data.Infrastructure;
using MINHTHUShop.Data.Migrations;
using MINHTHUShop.Data.Repositories;
using MINHTHUShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MINHTHUShop.Service
{
    public class Tb_RoleService : ITb_RoleService
    {
        private ITb_RoleRepository _roleRepository;
        private ITb_RoleGroupRepository _roleGroupRepository;
        private IUnitOfWork _unitOfWork;

        public Tb_RoleService(IUnitOfWork unitOfWork, ITb_RoleRepository roleRepository, ITb_RoleGroupRepository roleGroupRepository)
        {
            this._roleRepository = roleRepository;
            this._roleGroupRepository = roleGroupRepository;
            this._unitOfWork = unitOfWork;
        }

        public Tb_Role Create(Tb_Role role)
        {
            if (_roleRepository.CheckContains(x => x.Description == role.Description))
                throw new NameDuplicatedException("Tên đã tồn tại");
            return _roleRepository.Add(role);
        }

        public bool AddRolesToGroup(IEnumerable<Tb_RoleGroup> roleGroups, int groupID)
        {
            _roleGroupRepository.DeleteMulti(x => x.GroupID == groupID);
            foreach (var roleGroup in roleGroups)
            {
                _roleGroupRepository.Add(roleGroup);
            }
            return true;
        }

        public void Delete(string id)
        {
            _roleRepository.DeleteMulti(x => x.Id == id);
        }

        public IEnumerable<Tb_Role> GetAll()
        {
            return _roleRepository.GetAll();
        }

        public IEnumerable<Tb_Role> GetAll(int page, int pageSize, out int totalRow, string keyword = null)
        {
            var query = _roleRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Description.Contains(keyword) || x.Name.Contains(keyword));

            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public Tb_Role GetById(string id)
        {
            return _roleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Tb_Role role)
        {
            if (_roleRepository.CheckContains(x => x.Description == role.Description && x.Id != role.Id))
                throw new NameDuplicatedException("Tên đã tồn tại");
            _roleRepository.Update(role);
        }

        public IEnumerable<Tb_Role> GetListRoleByGroupID(int groupID)
        {
            return _roleRepository.GetListRoleByGroupID(groupID);
        }
    }

    public interface ITb_RoleService
    {
        Tb_Role GetById(string id);

        IEnumerable<Tb_Role> GetAll(int page, int pageSize, out int totalRow, string keyword);

        IEnumerable<Tb_Role> GetAll();

        Tb_Role Create(Tb_Role role);

        void Update(Tb_Role role);

        void Delete(string id);

        //Add roles to a sepcify group
        bool AddRolesToGroup(IEnumerable<Tb_RoleGroup> roleGroups, int groupID);

        //Get list role by group id
        IEnumerable<Tb_Role> GetListRoleByGroupID(int groupID);

        void SaveChanges();
    }
}