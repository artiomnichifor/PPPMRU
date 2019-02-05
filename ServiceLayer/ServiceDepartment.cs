using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using Repository.Interfaces;

namespace ServiceLayer
{
    public class ServiceDepartment : IServiceDepartment
    {
        private IRepository Repository { get; }

        public ServiceDepartment(IRepository repository)
        {
            this.Repository = repository;
        }

        public void CreateDepartment(Department department)
        {
            Repository.Create(department);
            Repository.Save();
        }
        public void EditDepartment(Department departmentModel, long id)
        {
            var department = Repository.GetById<Department>(id);

            department.DepartmentName = departmentModel.DepartmentName;
            department.ManagerName = departmentModel.ManagerName;

            Repository.Update<Department>(department);
            Repository.Save();
        }

        public void DeleteDepartment(Department department)
        {
            Repository.Delete<Department>(department);
            Repository.Save();
        }

        public DepartmentDto GetDepartmentDto(long id)
        {
            var result = Repository.GetById<Department>(id);
            return MapToDto(result);
        }
        public Department GetDepartment(long id)
        {
            var result = Repository.GetById<Department>(id);
            return result;
        }

        public IList<DepartmentDto> GetAllDepartments()
        {
            var departments = from d in Repository.GetAll<Department>()
                              select new DepartmentDto()
                              {
                                  Id = d.Id,
                                  DepartmentName = d.DepartmentName,
                                  ManagerName = d.ManagerName,
                                  NumberOfEmployees =
                                        (from e in Repository.GetAll<Employee>()
                                         where e.DepartmentId == d.Id
                                         select e).Count()
                              };
            return departments.ToList();
        }

        private DepartmentDto MapToDto(Department d)
        {
            return new DepartmentDto()
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                ManagerName = d.ManagerName,
                NumberOfEmployees = 
                        (from e in Repository.GetAll<Employee>()
                        where e.DepartmentId == d.Id
                        select e).Count()
            };
        }
    }
}
