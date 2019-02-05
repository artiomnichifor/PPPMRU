using Domain.Dto;
using System.Collections.Generic;
using Repository;
using Domain;
using System;
using Domain.Domain;

namespace ServiceLayer
{
    public interface IServiceEmployee
    {
        void CreateEmployee(Employee employee, User user, long role);
        void EditEmployee(Employee employee, long id);
        void DeleteEmployee(Employee employee);
        IList<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeDto(long id);
        Employee GetEmployee(long id);
        IList<RoleDto> GetAllRoles();

        IEnumerable<EmployeeDto> GetAllEmployeesQ();

    }
}