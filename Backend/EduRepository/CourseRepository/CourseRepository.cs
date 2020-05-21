using Core.DataTypes;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Functions.Course;
using Model.Tables.Edu;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EduRepository.CourseRepository
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration) : base(dbContext, memoryCache, configuration)
        {

        }


        public IEnumerable<Course> GetCourseOffer(Guid categoryId, Guid orgId, string city, Guid branch, int maxPrice, Guid courseId, Guid lectorId, Guid classRoomId, bool selectSomeDay, Dictionary<DaysInWeek, bool> selectedDays)
        {
            return null;
            /*        join cat in dbContext.CourseCategory on c.Id equals cat.CategoryId
                    join org in dbContext.Organization on c.OrganizationId equals org.Od
                    join l in dbContext.License on org.LicenseId equals l.Id
                    join t in dbContext.CourseTerms on c.Id equals t.CourseId
                    join cl in dbContext.ClassRoom on t.ClassRoomId equals cl.Id
                    join b in dbContext.Branch on cl.BranchId equals b.Id
                    join lector in dbContext.CourseLector on t.Id equals lector.CourseTermId
                    join student in dbContext.CourseStudent on t.Id equals student.CourseTermId
                    join u in dbContext.Person on lector.UserId equals u.UserId
                    where c.IsPrivateCourse == false &&
                    (c.CourseStatus == CourseStatus.IN_PREPARTION || c.CourseStatus == CourseStatus.OPEN) &&
                    ((t.RegistrationFrom >= DateTime.Now && t.RegistrationTo <= DateTime.Now) || t.RegistrationFrom == null || t.RegistrationTo == null) &&
                    (t.ActiveTo <= DateTime.Now || t.ActiveTo == null)
                    && (categoryId == 0 || cat.Id == categoryId)
                    && (orgId == 0 || org.Id == orgId) && (string.IsNullOrEmpty(city) || b.City == city) && (branch == 0 || b.Id == branch)
                    && (selectSomeDay == false || selectedDays[DaysInWeek.MONDAY] || selectedDays[DaysInWeek.THURSDAY] || selectedDays[DaysInWeek.WEDNESDAY] || selectedDays[DaysInWeek.TUESDAY] || selectedDays[DaysInWeek.FRIDAY] || selectedDays[DaysInWeek.SATURDAY] || selectedDays[DaysInWeek.SUNDAY])
                    && (courseId == 0 || c.Id == courseId) && (lectorId == 0 || lector.UserId == lectorId)
                    && (classRoom == 0 || cl.Id == classRoom)
                    && (studentId == 0 || student.UserId == studentId)
                    && (maxPrice == 0 || (t.Sale == 0 ?
                                         (t.Price == 0 ? c.DefaultPrice : t.Price) :
                                         (((t.Price == 0 ? c.DefaultPrice : t.Price) / 100) * t.Sale)
                                         ) <= maxPrice)
                    orderby l.Priority descending, t.ActiveFrom descending, c.Id
                    select new
                    {
                        c.CourseDescription,
                        c.CourseImage,
                        c.CourseName,
                        c.CourseType,
                        DefaultMaximumStudents = t.MaximumStudents,
                        c.DefaultMinimumStudents,
                        c.Id,
                        CoursePrice = t.Price == 0 ? c.DefaultPrice : t.Price,
                        CourseSale = t.Sale,
                        
                        org.OrganizationName,
                        t.Monday,
                        t.Tuesday,
                        t.Wednesday,
                        t.Thursday,
                        t.Friday,
                        t.Saturday,
                        t.Sunday,
                        
                        
                            LectorFirstName = u.FirstName,
                            LectorLastName = u.LastName,
                            LectorSecondName = u.SecondName,
                        

                        LectorId = u.UserId,
                        BranchId = b.Id,
                        OrganizationId = org.Id,
                        FreePlaces = t.MaximumStudents < 0 ? t.MaximumStudents : t.MaximumStudents - (from st in dbContext.CourseStudent where st.CourseTermId == t.Id select st).Count(),
                        TermId = t.Id,
                        Time = string.Format("{0}-{1}"),
                        b.Street,
                        b.City,
                        b.HouseNumber,
                        b.Region,
                        b.Country,
                        b.ZipCode
                    });*/
        }

        public List<GetAllCourseInOrganization> GetAllCourseInOrganization(Guid organizationId)
        {
            return CallSqlFunction<GetAllCourseInOrganization>("GetAllCourseInOrganization", new List<SqlParameter>()
            {
                new SqlParameter("@organizationId",organizationId)
            }).ToList();
        }

        public GetCourseDetail GetCourseDetail(Guid courseId)
        {
            return CallSqlFunction<GetCourseDetail>("GetCourseDetail", new List<SqlParameter>()
            {
                new SqlParameter("@courseId",courseId)
            }).FirstOrDefault();
        }

        public void AddCourse(AddCourse createCourse)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseTypeId", createCourse.CourseTypeId),
                new SqlParameter("@CourseStatusId", createCourse.CourseStatusId),
                new SqlParameter("@IsPrivateCourse", createCourse.IsPrivateCourse),
                new SqlParameter("@OrganizationId", createCourse.OrganizationId),
                new SqlParameter("@BasicInformationName", createCourse.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", createCourse.BasicInformationDescription),
                new SqlParameter("@CoursePrice", createCourse.CoursePrice),
                new SqlParameter("@CoursePriceSale", createCourse.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", createCourse.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", createCourse.StudentCountMaximumStudent)
            };
            CallSqlProcedure("CreateCourse", sqlParameters);
        }
        public void UpdateCourse(UpdateCourse updateCourse)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@CourseTypeId", updateCourse.CourseTypeId),
                new SqlParameter("@CourseStatusId", updateCourse.CourseStatusId),
                new SqlParameter("@IsPrivateCourse", updateCourse.IsPrivateCourse),
                new SqlParameter("@CourseId", updateCourse.CourseId),
                new SqlParameter("@BasicInformationName", updateCourse.BasicInformationName),
                new SqlParameter("@BasicInformationDescription", updateCourse.BasicInformationDescription),
                new SqlParameter("@CoursePrice", updateCourse.CoursePrice),
                new SqlParameter("@CoursePriceSale", updateCourse.CoursePriceSale),
                new SqlParameter("@StudentCountMinimumStudent", updateCourse.StudentCountMinimumStudent),
                new SqlParameter("@StudentCountMaximumStudent", updateCourse.StudentCountMaximumStudent)
            };
            CallSqlProcedure("UpdateCourse", sqlParameters);
        }
    }
}
