using EduFacade.AnswerFacade;
using EduFacade.AnswerFacade.Convertor;
using EduFacade.AuthFacade;
using EduFacade.AuthFacade.Convertor;
using EduFacade.BankOfQuestionFacade;
using EduFacade.BankOfQuestionFacade.Convertor;
using EduFacade.BranchFacade;
using EduFacade.BranchFacade.Convertor;
using EduFacade.ClassRoomFacade;
using EduFacade.ClassRoomFacade.Convertor;
using EduFacade.CodeBookFacade;
using EduFacade.CodeBookFacade.Convertor;
using EduFacade.CourseChapterFacade;
using EduFacade.CourseFacade;
using EduFacade.CourseFacade.Convertor;
using EduFacade.CourseLectorFacade;
using EduFacade.CourseLectorFacade.Convertor;
using EduFacade.CourseLessonFacade.Convertor;
using EduFacade.CourseLessonItemFacade;
using EduFacade.CourseLessonItemFacade.Convertor;
using EduFacade.CourseStudentFacade;
using EduFacade.CourseStudentFacade.Convertor;
using EduFacade.CourseTermFacade;
using EduFacade.CourseTermFacade.Convertor;
using EduFacade.FileUploadFacade;
using EduFacade.LicenseFacade;
using EduFacade.NotificationFacade;
using EduFacade.NotificationFacade.Convertor;
using EduFacade.OraganizationRoleFacade;
using EduFacade.OraganizationRoleFacade.Convertor;
using EduFacade.OrganizationFacade;
using EduFacade.OrganizationFacade.Convertor;
using EduFacade.QuestionFacade.Convertor;
using EduFacade.SliderFacade;
using EduFacade.SliderFacade.Convertor;
using EduFacade.UserFacade;
using EduFacade.UserFacade.Convertors;
using EduRepository.AnswerRepository;
using EduRepository.BranchRepository;
using EduRepository.ClassRoomRepository;
using EduRepository.CodeBookRepository;
using EduRepository.CourseChapterRepository;
using EduRepository.CourseLectorRepository;
using EduRepository.CourseRepository;
using EduRepository.CourseStudentRepository;
using EduRepository.CourseTermRepository;
using EduRepository.EmailRepository;
using EduRepository.FileUploadRepository;
using EduRepository.NotificationRepository;
using EduRepository.OrganizationRepository;
using EduRepository.OrganizationRoleRepository;
using EduRepository.QuestionRepository;
using EduRepository.RoleRepository;
using EduRepository.SliderRepository;
using EduRepository.UserRepository;
using EduServices.AccessTokenService;
using EduServices.AnswerService;
using EduServices.BranchService;
using EduServices.ClassRoomService;
using EduServices.CodeBookService;
using EduServices.CourseChapterService;
using EduServices.CourseLectorService;
using EduServices.CourseService;
using EduServices.CourseStudentService;
using EduServices.CourseTermService;
using EduServices.FileUploadService;
using EduServices.LicenseService;
using EduServices.NotificationService;
using EduServices.OrganizationRoleService;
using EduServices.OrganizationService;
using EduServices.QuestionService;
using EduServices.RoleService;
using EduServices.SendMailService;
using EduServices.SliderService;
using EduServices.UserService;
using Integration.SendGrid;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration
{
    public static class IServiceCollectionExt
    {
        public static void RegistrationCodeBook(this IServiceCollection service)
        {
            service.AddScoped<ICodeBookFacade, CodeBookFacade>();
            service.AddScoped<ICodeBookService, CodeBookService>();
            service.AddScoped<ICodeBookRepository, CodeBookRepository>();
            service.AddScoped<ICodeBookConvertor, CodeBookConvertor>();
        }
        public static void RegisterEmail(this IServiceCollection service)
        {
            service.AddScoped<IEmailRepository, EmailRepository>();
            service.AddScoped<ISendMailService, SendMailService>();
            service.AddScoped<ISendGridIntegration, SendGridIntegration>();
        }
        public static void RegistrationUser(this IServiceCollection service)
        {
            service.AddScoped<IUserFacade, UserFacade>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserConvertor, UserConvertor>();
            service.AddScoped<IAddressConvertor, AddressConvertor>();
        }
        public static void RegistrationRole(this IServiceCollection service)
        {
            service.AddScoped<IRoleService, RoleService>();
            service.AddScoped<IRoleRepository, RoleRepository>();
        }
        public static void RegistrationOrganizationRole(this IServiceCollection service)
        {
            service.AddScoped<IOrganizationRoleFacade, OrganizationRoleFacade>();
            service.AddScoped<IOrganizationRoleService, OrganizationRoleService>();
            service.AddScoped<IOrganizationRoleRepository, OrganizationRoleRepository>();
            service.AddScoped<IOraganizationRoleConvertor, OraganizationRoleConvertor>();
        }
        public static void RegistrationAccessToken(this IServiceCollection service)
        {
            service.AddScoped<IAuthFacade, AuthFacade>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IAuthConvertor, AuthConvertor>();
        }

        public static void RegistrationOrganization(this IServiceCollection service)
        {
            service.AddScoped<IOrganizationRepository, OrganizationRepository>();
            service.AddScoped<IOrganizationService, OrganizationService>();
            service.AddScoped<IOrganizationFacade, OrganizationFacade>();
            service.AddScoped<IOrganizationConvertor, OrganizationConvertor>();
        }
        public static void RegisterLicense(this IServiceCollection service)
        {
            service.AddScoped<ILicenseFacade, LicenseFacade>();
            service.AddScoped<ILicenseService, LicenseService>();
        }
        public static void RegisterBranch(this IServiceCollection service)
        {
            service.AddScoped<IBranchRepository, BranchRepository>();
            service.AddScoped<IBranchFacade, BranchFacade>();
            service.AddScoped<IBranchService, BranchService>();
            service.AddScoped<IBranchConvertor, BranchConvertor>();
        }
        public static void RegistrationCourse(this IServiceCollection service)
        {
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddScoped<ICourseFacade, CourseFacade>();
            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<ICourseConvertor, CourseConvertor>();
        }

        public static void RegistrationSlider(this IServiceCollection service)
        {
            service.AddScoped<ISliderRepository, SliderRepository>();
            service.AddScoped<ISliderFacade, SliderFacade>();
            service.AddScoped<ISliderService, SliderService>();
            service.AddScoped<ISliderConvertor, SliderConvertor>();
        }

        public static void RegistrationClassRoom(this IServiceCollection services)
        {
            services.AddScoped<IClassRoomFacade, ClassRoomFacade>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
            services.AddScoped<IClassRoomConvertor, ClasssRoomConvertor>();
        }
        public static void RegistrationCourseTerm(this IServiceCollection services)
        {
            services.AddScoped<ICourseTermFacade, CourseTermFacade>();
            services.AddScoped<ICourseTermConvertor, CourseTermConvertor>();
            services.AddScoped<ICourseTermService, CourseTermService>();
            services.AddScoped<ICourseTermRepository, CourseTermRepository>();
        }
        public static void RegistrationCourseLectorFacade(this IServiceCollection services)
        {
            services.AddScoped<ICourseLectorFacade, CourseLectorFacade>();
            services.AddScoped<ICourseLectorService, CourseLectorService>();
            services.AddScoped<ICourseLectorConvertor, CourseLectorConvertor>();
            services.AddScoped<ICourseLectorRepository, CourseLectorRepository>();
        }
        public static void RegistrionCourseStudentFacade(this IServiceCollection services)
        {
            services.AddScoped<ICourseStudentFacade, CourseStudentFacade>();
            services.AddScoped<ICourseStudentService, CourseStudentService>();
            services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            services.AddScoped<ICourseStudentConvertor, CourseStudentConvertor>();
        }
        public static void RegistrationCourseLesson(this IServiceCollection services)
        {
            services.AddScoped<ICourseLessonFacade, CourseLessonFacade>();
            services.AddScoped<ICourseLessonService, CourseLessonService>();
            services.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
            services.AddScoped<ICourseLessonConvertor, CourseLessonConvertor>();
        }
        public static void RegistrationCourseLessonItem(this IServiceCollection services)
        {
            services.AddScoped<ICourseLessonItemFacade, CourseLessonItemFacade>();
            services.AddScoped<ICourseLessonItemService, CourseLessonItemService>();
            services.AddScoped<ICourseLessonItemRepository, CourseLessonItemRepository>();
            services.AddScoped<ICourseLessonItemConvertor, CourseLessonItemConvertor>();
        }
        public static void RegistratioBankOfQuestion(this IServiceCollection services)
        {
            services.AddScoped<IBankOfQuestionFacade, BankOfQuestionFacade>();
            services.AddScoped<IBankOfQuestionConvertor, BankOfQuestionConvertor>();
            services.AddScoped<IBankOfQuestionService, BankOfQuestionService>();
            services.AddScoped<IBankOfQuestionRepository, BankOfQuestionRepository>();
        }
        public static void RegistrationQuestion(this IServiceCollection services)
        {
            services.AddScoped<IQuestionFacade, QuestionFacade>();
            services.AddScoped<IQuestionConvertor, QuestionConvertor>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
        }
        public static void RegistrationAnswer(this IServiceCollection services)
        {
            services.AddScoped<IAnswerFacade, AnswerFacade>();
            services.AddScoped<IAnswerConvertor, AnswerConvertor>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
        }
        public static void RegisterNotification(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationFacade, NotificationFacade>();
            services.AddScoped<INotificationConvertor, NotificationConvertor>();
        }
        public static void RegisterFileUpload(this IServiceCollection services)
        {
            services.AddScoped<IFileUploadFacade, FileUploadFacade>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
        }

    }
}
