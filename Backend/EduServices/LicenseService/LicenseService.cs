using EduCore.DataTypes;
using EduCore.EduOperation.Branch;
using EduCore.EduOperation.Course;
using EduRepository.BranchRepository;
using EduRepository.CourseRepository;
using EduRepository.OrganizationRepository;
using Model.Functions.License;
using System;
using System.Linq;

namespace EduServices.LicenseService
{
    public class LicenseService : BaseService, ILicenseService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICourseRepository _courseRepository;
        public LicenseService(IOrganizationRepository organizationRepository, IBranchRepository branchRepository, ICourseRepository courseRepository)
        {
            _branchRepository = branchRepository;
            _organizationRepository = organizationRepository;
            _courseRepository = courseRepository;

        }

        public bool ValidateLicence(Guid organizationId, BaseOperation operation)
        {
            GetLicenseByOrganization license = _organizationRepository.GetLicenseByOrganization(organizationId);
            if (license == null)
            {
                return false;
            }
            if (operation.OperationCode == new AddBranchOperation().OperationCode)
            {
                return license.MaximumBranch > 0 ?
                    _branchRepository.GetAllBranchInOrganization(organizationId).ToList().Count+1 <= license.MaximumBranch :
                     true;
            }
            if (operation.OperationCode == new AddCourseOperation().OperationCode)
            {
                return license.MaximumCourse > 0 ?
                    _courseRepository.GetAllCourseInOrganization(organizationId).ToList().Count+1 <= license.MaximumCourse :
                    true;
            }
            return true;
        }
    }
}