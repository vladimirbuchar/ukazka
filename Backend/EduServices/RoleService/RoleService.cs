using EduRepository.RoleRepository;
using Model.Tables.Edu;

namespace EduServices.RoleService
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public UserRole GetUserRole(string identificator)
        {
            return _roleRepository.GetEntity<UserRole>(identificator);
        }
    }
}
