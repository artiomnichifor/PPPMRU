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
    public class EventController : Controller
    {
        private readonly IServiceEvent service;
        public EventController(IServiceEvent serviceEvent)
        {
            this.service = serviceEvent;
        }
        // GET: Event
        public ActionResult Index()
        {
            var eventDtos = service.GetAllEvents();
            return View(eventDtos);
        }

        // GET: Event/Details/5
        public ActionResult Details(long id)
        {
            var evnt = service.GetEventDto(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            return View(evnt);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "Id,EventName,EventDate,StartTime,EndTime,Subject")]*/ EventModel model)
        {
            if (ModelState.IsValid)
            {
                var evnt = new Event(model.EventName, model.EventDate, model.StartTime, model.EndTime, model.Subject);

                service.CreateEvent(evnt);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(long id)
        {
            var evnt = service.GetEvent(id);
            if (evnt == null)
            {
                return HttpNotFound();
            }
            var eventModel = new EventModel
            {
                Id = evnt.Id,
                EventName = evnt.EventName,
                EventDate = evnt.EventDate,
                StartTime = evnt.StartTime,
                EndTime = evnt.EndTime,
                Subject = evnt.Subject
            };

            return View(eventModel);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "Id,EventName,EventDate,StartTime,EndTime,Subject")]*/ EventModel model)
        {
            if(ModelState.IsValid)
            {
                var evnt = new Event(model.EventName, model.EventDate, model.StartTime, model.EndTime, model.Subject);
                service.EditEvent(evnt, model.Id);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        

        // GET: Event/Delete/5
        public ActionResult Delete(long id)
        {
            var eventDto = service.GetEventDto(id);
            if (eventDto == null)
            {
                return HttpNotFound();
            }
            return View(eventDto);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var evnt = service.GetEvent(id);
            service.DeleteEvent(evnt);
            return RedirectToAction("Index");
        }



    }
}
