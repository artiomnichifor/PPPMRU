using DataAccessLayer;
using Domain;
using Domain.Domain;
using Mvc_v1.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_v1.Controllers
{
    public class GridEmployeeController : Controller
    {
        private readonly IServiceEmployee service;
        private readonly IServiceDepartment departmentService;
        public GridEmployeeController(IServiceEmployee serviceEmployee, IServiceDepartment serviceDepartment)
        {
            this.service = serviceEmployee;
            this.departmentService = serviceDepartment;
        }

        // GET: GridEmployee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees(string sidx, string sort, int page, int rows)
        {
            //EmployeeManagementContext db = new EmployeeManagementContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var EmployeeList = service.GetAllEmployeesQ();
            int totalRecords = EmployeeList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                EmployeeList = EmployeeList.OrderByDescending(t => t.FirstName);
                EmployeeList = EmployeeList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                EmployeeList = EmployeeList.OrderBy(t => t.FirstName);
                EmployeeList = EmployeeList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = EmployeeList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] UserEmployeeModel model)
        {
            string msg;

            if (ModelState.IsValid)
            {
                var employee = new Employee(model.FirstName, model.LastName, model.Email, model.DateOfEmployment, model.DepartmentId);
                var user = new User()
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true,
                    ActivationCode = Guid.NewGuid(),
                };

                service.CreateEmployee(employee, user, model.RoleId);
                msg = "Saved Successfully";
                return msg;
            };

            //ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName", model.DepartmentId);
            msg = "Saved Successfully";
            return msg;
        }


        public string Edit(EmployeeModel model)
        {
            string msg;

            if (ModelState.IsValid)
            {
                //new Employee()
                var employee = new Employee(model.FirstName, model.LastName, model.Email, model.DateOfEmployment, model.DepartmentId);
                service.EditEmployee(employee, model.Id);

                msg = "Saved Successfully";
                return msg;
            }
            //ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName", model.DepartmentId);
            msg = "Saved Successfully";

            return msg;
        }

        public string Delete(long id)
        {
            var employee = service.GetEmployee(id);
            service.DeleteEmployee(employee);
            
            return "Deleted successfully";
        }


    }
}