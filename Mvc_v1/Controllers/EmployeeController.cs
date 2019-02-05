using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Domain;
using Domain.Domain;
using Mvc_v1.Authentication;
using Mvc_v1.Models;
using ServiceLayer;

namespace Mvc_v1.Controllers
{
    //[CustomAuthorize]
    public class EmployeeController : Controller
    {
        private readonly IServiceEmployee service;
        private readonly IServiceDepartment departmentService;
        public EmployeeController(IServiceEmployee serviceEmployee, IServiceDepartment serviceDepartment)
        {
            this.service = serviceEmployee;
            this.departmentService = serviceDepartment;
        }
        // GET: Employee
        public ActionResult Index(/*string sortOrder*/)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "DateOfEmployment" ? "DateOfEmployment_desc" : "DateOfEmployment";

            var employeeDtos = service.GetAllEmployees();
            return View(employeeDtos);
        }
        [CustomAuthorize(Roles ="User")]
        // GET: Employee/Details/5
        public ActionResult Details(long id)
        {
            var employeeDto = service.GetEmployeeDto(id);
            if (employeeDto == null)
            {
                return HttpNotFound();
            }
            return View(employeeDto);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName");
            ViewBag.RoleId = new SelectList(service.GetAllRoles(), "Id", "RoleName");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,FirstName,LastName,Email,DateOfEmployment,DepartmentId")]*/ UserEmployeeModel model)
        {
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
                return RedirectToAction("Index");
            };

            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName", model.DepartmentId);
            return View(model);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(long id)
        {
            var employee = service.GetEmployee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            var employeeModel = new EmployeeModel { Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfEmployment = employee.DateOfEmployment,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId };

            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName", employee.DepartmentId);
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,DateOfEmployment,DepartmentId")] EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                //new Employee()
                var employee = new Employee(model.FirstName, model.LastName, model.Email, model.DateOfEmployment, model.DepartmentId);
                service.EditEmployee(employee, model.Id);

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), "Id", "DepartmentName", model.DepartmentId);
            return View(model);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(long id)
        {
            var employeeDto = service.GetEmployeeDto(id);
            if (employeeDto == null)
            {
                return HttpNotFound();
            }
            return View(employeeDto);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var employee = service.GetEmployee(id);
            service.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //service.Dispose();
            base.Dispose(disposing);
        }
    }
}
