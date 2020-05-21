using EduCore.DataTypes;
using EduServices.LicenseService;
using System;

namespace EduFacade.LicenseFacade
{
    public class LicenseFacade : BaseFacade, ILicenseFacade
    {
        private readonly ILicenseService _licenseService;
        public LicenseFacade(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        public bool ValidateLicence(Guid organizationId, BaseOperation operation)
        {
            return _licenseService.ValidateLicence(organizationId, operation);
        }
    }
}
