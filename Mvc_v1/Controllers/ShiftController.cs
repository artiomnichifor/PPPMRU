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
using ServiceLayer;

namespace Mvc_v1.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IServiceShift service;
        private readonly IServiceEmployee serviceEmployee;
        public ShiftController(IServiceShift serviceShift, IServiceEmployee serviceEmployee)
        {
            this.service = serviceShift;
            this.serviceEmployee = serviceEmployee;
        }

        // GET: Shift
        public ActionResult Index()
        {
            var shiftDtos = service.GetAllShifts();
            return View(shiftDtos);
        }

        // GET: Shift/Details/5
        public ActionResult Details(long id)
        {
            var shiftDto = service.GetShiftDto(id);
            if (shiftDto == null)
            {
                return HttpNotFound();
            }
            return View(shiftDto);
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName");
            return View();
        }

        // POST: Shift/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShiftName,StartTime,EndTime,BreakTime")] ShiftModel model)
        {
            if (ModelState.IsValid)
            {
                var shift = new Shift(model.Id, model.ShiftName, model.StartTime, model.EndTime, model.BreakTime);
                service.CreateShift(shift);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: Shift/Edit/5
        public ActionResult Edit(long id)
        {
            var shift = service.GetShift(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            var shiftModel = new ShiftModel
            {
                Id = shift.Id,
                ShiftName = shift.ShiftName,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime,
                BreakTime = shift.BreakTime
            };

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", shift.Id);
            return View(shiftModel);
        }

        // POST: Shift/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShiftName,StartTime,EndTime,BreakTime")] ShiftModel model)
        {
            if (ModelState.IsValid)
            {
                //new Employee()
                var shift = new Shift(model.ShiftName, model.StartTime, model.EndTime, model.BreakTime);
                service.EditShift(shift, model.Id);

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: Shift/Delete/5
        public ActionResult Delete(long id)
        {
            var shiftDto = service.GetShiftDto(id);
            if (shiftDto == null)
            {
                return HttpNotFound();
            }

            return View(shiftDto);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var shift = service.GetShift(id);
            service.DeleteShift(shift);
            return RedirectToAction("Index");
        }

        
    }
}
