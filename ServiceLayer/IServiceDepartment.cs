using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;

namespace ServiceLayer
{
    public interface IServiceDepartment
    {
        void CreateDepartment(Department department);
        void EditDepartment(Department departmentModel, long id);
        void DeleteDepartment(Department department);
        DepartmentDto GetDepartmentDto(long id);
        Department GetDepartment(long id);
        IList<DepartmentDto> GetAllDepartments();
    }
}
