using System;
using Domain;
using Domain.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServiceSalary
    {
        void CreateSalary(Salary salary);
        void EditSalary(Salary salaryModel, long id);
        void DeleteSalary(Salary salary);
        IList<SalaryDto> GetAllSalaries();
        SalaryDto GetSalaryDto(long id);
        Salary GetSalary(long id);
    }
}
