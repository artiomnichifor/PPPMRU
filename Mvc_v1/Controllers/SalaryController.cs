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
using Mvc_v1.Models;
using Repository;
using ServiceLayer;

namespace Mvc_v1.Controllers
{
    public class SalaryController : Controller
    {
        private readonly IServiceSalary service;
        private readonly IServiceEmployee serviceEmployee;
        public SalaryController(IServiceSalary serviceSalary, IServiceEmployee serviceEmployee)
        {
            this.service = serviceSalary;
            this.serviceEmployee = serviceEmployee;
        }

        // GET: Salaries
        public ActionResult Index()
        {
            var salaryDtos = service.GetAllSalaries();
            return View(salaryDtos);
        }

        // GET: Salaries/Details/5
        public ActionResult Details(long id)
        {
            var salaryDto = service.GetSalaryDto(id);
            if (salaryDto == null)
            {
                return HttpNotFound();
            }
            return View(salaryDto);
        }

        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName");
            return View();
        }

        // POST: Salaries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkingHours,SalaryPerHour")] SalaryModel model)
        {
            if (ModelState.IsValid)
            {
                var salary = new Salary(model.Id, model.WorkingHours, model.SalaryPerHour);
                service.CreateSalary(salary);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: Salaries/Edit/5
        public ActionResult Edit(long id)
        {
            var salary = service.GetSalary(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            var salaryModel = new SalaryModel
            {
                Id = salary.Id,
                WorkingHours = salary.WorkingHours,
                SalaryPerHour = salary.SalaryPerHour
            };

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", salary.Id);
            return View(salaryModel);
        }

        // POST: Salaries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkingHours,SalaryPerHour")] SalaryModel model)
        {
            if (ModelState.IsValid)
            {
                //new Employee()
                var salary = new Salary(model.WorkingHours, model.SalaryPerHour);
                service.EditSalary(salary, model.Id);

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: Salaries/Delete/5
        public ActionResult Delete(long id)
        {
            var salaryDto = service.GetSalaryDto(id);
            if (salaryDto == null)
            {
                return HttpNotFound();
            }

            return View(salaryDto);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var salary = service.GetSalary(id);
            service.DeleteSalary(salary);
            return RedirectToAction("Index");
        }
    }
}
