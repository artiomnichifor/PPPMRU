using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Repository.Interfaces;
using Domain;
using Repository.Implementation;
using Mvc_v1.Controllers;
using Unity.Injection;
using ServiceLayer;
using DataAccessLayer;
using Unity.Lifetime;
using System.Data.Entity;
using System.Collections.Generic;
using Domain.Domain;
using System.Collections;

namespace Mvc_v1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // MVC
            //DependencyResolver.SetResolver(
            //    new UnityDependencyResolver(container));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IRepository<Employee>, Repository<Employee>>();
            //container.RegisterType<IRepository<Department>, Repository<Department>>();
            //container.RegisterType<IRepository<Shift>, Repository<Shift>>();
            //container.RegisterType<IRepository<Salary>, Repository<Salary>>();
            //container.RegisterType<IRepository<Event>, Repository<Event>>();
            //container.RegisterType<IRepository<PersonalData>, Repository<PersonalData>>();

            //container.RegisterType<DbContext, EmployeeManagementContext>(new HierarchicalLifetimeManager(), new InjectionConstructor());
            //container.RegisterType<EmployeeManagementContext>(new HierarchicalLifetimeManager());


            container.RegisterType<IRepository, Repository.Implementation.Repository>();
            //container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            //container.RegisterType<IDepartmentRepository, DepartmentRepository>();

            container.RegisterType<IServiceDepartment, ServiceDepartment>();
            container.RegisterType<IServiceEmployee, ServiceEmployee>();
            container.RegisterType<IServiceShift, ServiceShift>();
            container.RegisterType<IServicePersonalData, ServicePersonalData>();
            container.RegisterType<IServiceSalary, ServiceSalary>();
            container.RegisterType<IServiceEvent, ServiceEvent>();

            //container.RegisterType<ICollection, List<Role>>();



            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            //container.RegisterType<UsersAdminController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}