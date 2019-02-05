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
    public class PersonalDataController : Controller
    {
        private readonly IServicePersonalData service;
        private readonly IServiceEmployee serviceEmployee;
        public PersonalDataController(IServicePersonalData personalDataShift, IServiceEmployee serviceEmployee)
        {
            this.service = personalDataShift;
            this.serviceEmployee = serviceEmployee;
        }

        // GET: PersonalData
        public ActionResult Index()
        {
            var persoanlaDataDtos = service.GetAllPersonalDatas();
            return View(persoanlaDataDtos);
        }

        // GET: PersonalData/Details/5
        public ActionResult Details(long id)
        {
            var persoanalDataDto = service.GetPersonalDataDto(id);
            if (persoanalDataDto == null)
            {
                return HttpNotFound();
            }
            return View(persoanalDataDto);
        }

        // GET: PersonalData/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName");
            return View();
        }

        // POST: PersonalData/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Adress,PhoneNumber,DateOfBirth")] PersonalDataModel model)
        {
            if (ModelState.IsValid)
            {
                var personalData = new PersonalData(model.Id, model.Adress, model.PhoneNumber, model.DateOfBirth);
                service.CreatePersonalData(personalData);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: PersonalData/Edit/5
        public ActionResult Edit(long id)
        {
            var personalData = service.GetPersonalData(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            var personalDataModel = new PersonalDataModel
            {
                Id = personalData.Id,
                Adress = personalData.Adress,
                PhoneNumber = personalData.PhoneNumber,
                DateOfBirth = personalData.DateOfBirth
            };

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", personalData.Id);
            return View(personalDataModel);
        }

        // POST: PersonalData/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Adress,PhoneNumber,DateOfBirth")] PersonalDataModel model)
        {
            if (ModelState.IsValid)
            {
                var personalData = new PersonalData(model.Adress, model.PhoneNumber, model.DateOfBirth);
                service.EditPersonalData(personalData, model.Id);

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(serviceEmployee.GetAllEmployees(), "Id", "FirstName", model.Id);
            return View(model);
        }

        // GET: PersonalData/Delete/5
        public ActionResult Delete(long id)
        {
            var personalDataDto = service.GetPersonalDataDto(id);
            if (personalDataDto == null)
            {
                return HttpNotFound();
            }

            return View(personalDataDto);
        }

        // POST: PersonalData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var personalData = service.GetPersonalData(id);
            service.DeletePersonalData(personalData);
            return RedirectToAction("Index");
        }
    }
}
