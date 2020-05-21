using Model.Tables.Edu;

namespace EduServices.RoleService
{
    public interface IRoleService : IBaseService
    {
        UserRole GetUserRole(string identificator);
    }
}
