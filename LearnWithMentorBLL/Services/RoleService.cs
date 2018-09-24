using System.Collections.Generic;
using LearnWithMentorBLL.Interfaces;
using LearnWithMentorDTO;
using LearnWithMentorDAL.UnitOfWork;
using LearnWithMentorDAL.Entities;

namespace LearnWithMentorBLL.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IUnitOfWork db) : base(db)
        {
        }
        public RoleDTO Get(int id)
        {
            var role = db.Roles.Get(id);
            return role == null ? null :
                new RoleDTO(role.Id, role.Name);
        }
        public List<RoleDTO> GetAllRoles()
        {
            var roles = db.Roles.GetAll();
            if (roles == null)
            {
                return null;
            }
            var dtos = new List<RoleDTO>();
            foreach (var role in roles)
            {
                dtos.Add(new RoleDTO(role.Id, role.Name));
            }
            return dtos;
        }
        public RoleDTO GetByName(string name)
        {
            Role role;
            if (!db.Roles.TryGetByName(name, out role))
            {
                return null;
            }
            return new RoleDTO(role.Id, role.Name);
        }
    }
}
