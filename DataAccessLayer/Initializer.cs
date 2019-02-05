using Domain;
using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeeManagementContext>
    {
        protected override void Seed(EmployeeManagementContext context)
        {
            var roles = new List<Role>
            {
                new Role{RoleName = "admin"},
                new Role{RoleName = "user"}
            };

            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department("dep1", "man1")
            };
            
            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var dep = (from d in context.Departments
                      select d).First();

            var employees = new List<Employee>
            {
                new Employee("aaa", "aaa", "email@email.com", DateTime.Now, dep.Id)
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var role = (from r in context.Roles
                        where r.RoleName == "admin"
                        select r).First();
            var roleList = new List<Role>();
            roleList.Add(role);

            var adminEmployee = (from e in context.Employees
                                 where e.FirstName == "aaa"
                                 select e).First();

            var users = new List<User>
            {
                new User{ Username = "admin", FirstName = "aaa", LastName = "aaa", Password = "zxcv1234", Email = "mail@email.com", Roles = roleList, Employee = adminEmployee, IsActive = true }

            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            
            
        }

    }
}