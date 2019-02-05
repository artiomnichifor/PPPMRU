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
    public class DepartmentController : Controller
    {
        private readonly IServiceDepartment service;

        public DepartmentController(IServiceDepartment serviceDepartment)
        {
            this.service = serviceDepartment;
        }

        // GET: Department
        public ActionResult Index()
        {
            var departmentDtos = service.GetAllDepartments();
            return View(departmentDtos);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var departmentDto = service.GetDepartmentDto(id);
            if (departmentDto == null)
            {
                return HttpNotFound();
            }
            return View(departmentDto);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentName,ManagerName")] DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department(model.DepartmentName, model.DepartmentName);
                service.CreateDepartment(department);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(long id)
        {
            var department = service.GetDepartment(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            var departmentModel = new DepartmentModel
            {
                Id = department.Id,
                DepartmentName = department.DepartmentName,
                ManagerName = department.ManagerName
            };
            return View(departmentModel);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentName,ManagerName")] Department model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department(model.DepartmentName, model.ManagerName);
                service.EditDepartment(department, model.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var departmentDto = service.GetDepartmentDto(id);
            if (departmentDto == null)
            {
                return HttpNotFound();
            }

            return View(departmentDto);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var department = service.GetDepartment(id);
            service.DeleteDepartment(department);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
            base.Dispose(disposing);
        }
    }
}
