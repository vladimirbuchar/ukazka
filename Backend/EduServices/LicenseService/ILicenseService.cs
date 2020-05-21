using EduCore.DataTypes;
using System;

namespace EduServices.LicenseService
{
    public interface ILicenseService : IBaseService
    {
        bool ValidateLicence(Guid organizationOd, BaseOperation operation);
    }
}
