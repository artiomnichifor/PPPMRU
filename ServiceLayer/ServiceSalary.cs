using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Dto;
using Repository.Interfaces;

namespace ServiceLayer
{
    public class ServiceSalary : IServiceSalary
    {
        private IRepository Repository { get; }

        public ServiceSalary(IRepository repository)
        {
            this.Repository = repository;
        }

        public void CreateSalary(Salary salary)
        {
            Repository.Create(salary);
            Repository.Save();
        }

        public void DeleteSalary(Salary salary)
        {
            Repository.Delete(salary);
            Repository.Save();
        }

        public void EditSalary(Salary salaryModel, long id)
        {
            var salary = Repository.GetById<Salary>(id);

            salary.WorkingHours = salaryModel.WorkingHours;
            salary.SalaryPerHour = salaryModel.SalaryPerHour;

            Repository.Update<Salary>(salary);
            Repository.Save();
        }

        public IList<SalaryDto> GetAllSalaries()
        {
            var salaries = from s in Repository.GetAll<Salary>()
                            select new SalaryDto()
                            {
                                Id = s.Id,
                                WorkingHours = s.WorkingHours,
                                SalaryPerHour = s.SalaryPerHour
                            };


            return salaries.ToList();
        }

        public Salary GetSalary(long id)
        {
            var result = Repository.GetById<Salary>(id);
            return result;
        }

        public SalaryDto GetSalaryDto(long id)
        {
            var result = Repository.GetById<Salary>(id);
            return MapToDto(result);
        }

        private SalaryDto MapToDto(Salary s)
        {
            return new SalaryDto()
            {
                Id = s.Id,
                WorkingHours = s.WorkingHours,
                SalaryPerHour = s.SalaryPerHour
            };
        }
    }
}
