using DataAccessLayer.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;
using Domain.Domain;
using System.Diagnostics;

namespace DataAccessLayer
{

    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext() : base("MvcEmployeeDB_v3")
        {
            Database.SetInitializer<EmployeeManagementContext>(new DropCreateDatabaseIfModelChanges<EmployeeManagementContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PersonalDataConfig());

            modelBuilder.Configurations.Add(new DepartmentConfig());

            modelBuilder.Configurations.Add(new EmployeeConfig());

            modelBuilder.Configurations.Add(new EventConfig());

            modelBuilder.Configurations.Add(new SalaryConfig());

            modelBuilder.Configurations.Add(new ShiftConfig());

            modelBuilder.Configurations.Add(new UserConfig());
        }
    }
}