using EduCore.DataTypes;
using System;

namespace EduFacade.LicenseFacade
{
    public interface ILicenseFacade
    {
        bool ValidateLicence(Guid organizationId, BaseOperation operation);
    }
}
