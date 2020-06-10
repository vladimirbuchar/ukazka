using Microsoft.EntityFrameworkCore;
using Model.Tables.CodeBook;
using Model.Tables.Edu;
using Model.Tables.Link;
using Model.Tables.Shared;
using Model.Tables.System;

namespace Model
{
    public class EduDbContext : DbContext
    {
        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public EduDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetTableDefault<Category>(modelBuilder);
            SetTableDefault<Course>(modelBuilder);
            SetTableDefault<CourseCategory>(modelBuilder);
            SetTableDefault<CourseLessonItem>(modelBuilder);
            SetTableDefault<CourseLector>(modelBuilder);
            SetTableDefault<CourseRate>(modelBuilder);
            SetTableDefault<CourseStudent>(modelBuilder);
            SetTableDefault<CourseTerm>(modelBuilder);
            SetTableDefault<LectorRate>(modelBuilder);
            SetTableDefault<User>(modelBuilder);
            SetTableDefault<UserInRole>(modelBuilder);
            SetTableDefault<UserRole>(modelBuilder);
            SetTableDefault<CourseTest>(modelBuilder);
            SetTableDefault<TestQuestion>(modelBuilder);
            SetTableDefault<TestQuestionAnswer>(modelBuilder);
            SetTableDefault<DataMigration>(modelBuilder);
            SetTableDefault<Person>(modelBuilder);
            SetTableDefault<Organization>(modelBuilder);
            SetTableDefault<Branch>(modelBuilder);
            SetTableDefault<ClassRoom>(modelBuilder);
            SetTableDefault<License>(modelBuilder);
            SetTableDefault<Culture>(modelBuilder);
            SetTableDefault<Slider>(modelBuilder);
            SetTableDefault<Job>(modelBuilder);
            SetTableDefault<Inquiry>(modelBuilder);
            SetTableDefault<UserInOrganization>(modelBuilder);
            SetTableDefault<OrganizationRole>(modelBuilder);
            SetTableDefault<OrganizationRolePermition>(modelBuilder);
            SetTableDefault<StudentTestSummary>(modelBuilder);
            SetTableDefault<Address>(modelBuilder);
            SetTableDefault<BasicInformation>(modelBuilder);
            SetTableDefault<AddressType>(modelBuilder);
            SetTableDefault<GalleryItemType>(modelBuilder);
            SetTableDefault<ContactInformation>(modelBuilder);
            SetTableDefault<Gallery>(modelBuilder);
            SetTableDefault<ObjectHistory>(modelBuilder);
            SetTableDefault<CoursePrice>(modelBuilder);
            SetTableDefault<StudentCount>(modelBuilder);
            SetTableDefault<CourseStatus>(modelBuilder);
            SetTableDefault<CourseType>(modelBuilder);
            SetTableDefault<TimeTable>(modelBuilder);
            SetTableDefault<TestStudentResult>(modelBuilder);
            SetTableDefault<EduEmail>(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.UserEmail).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        private void SetTableDefault<T>(ModelBuilder modelBuilder) where T : TableModel
        {
            modelBuilder.Entity<T>().HasIndex(u => u.SystemIdentificator).IsUnique();
            modelBuilder.Entity<T>().Property(u => u.Id).ValueGeneratedOnAdd();
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<CourseLessonItem> CourseItem { get; set; }
        public DbSet<CourseLector> CourseLector { get; set; }
        public DbSet<CourseRate> CourseRate { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseTerm> CourseTerm { get; set; }
        public DbSet<LectorRate> LectorRate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<CourseTest> CourseTest { get; set; }
        public DbSet<TestQuestion> TestQuestion { get; set; }
        public DbSet<TestQuestionAnswer> TestQuestionAnswer { get; set; }
        public DbSet<DataMigration> DataMigration { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<Culture> Culture { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Inquiry> Inquiry { get; set; }
        public DbSet<UserInOrganization> UserInOrganization { get; set; }
        public DbSet<OrganizationRole> OrganizationRole { get; set; }
        public DbSet<OrganizationRolePermition> OrganizationRolePermition { get; set; }
        public DbSet<StudentTestSummary> StudentTestSummary { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BasicInformation> BasicInformation { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<GalleryItemType> GalleryItemType { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<ObjectHistory> ObjectHistory { get; set; }
        public DbSet<CoursePrice> CoursePrice { get; set; }
        public DbSet<StudentCount> StudentCount { get; set; }
        public DbSet<CourseStatus> CourseStatus { get; set; }
        public DbSet<CourseType> CourseType { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<TestStudentResult> TestStudentResult { get; set; }
        public DbSet<EduEmail> EduEmails { get; set; }
        public DbSet<CourseLessonItemTemplate> CourseLessonItemTemplate { get; set; }
        public DbSet<FileRepository> FileRepository { get; set; }
    }
}