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
    public class ServiceEvent : IServiceEvent
    {
        private IRepository Repository { get; }

        public ServiceEvent(IRepository repository)
        {
            this.Repository = repository;
        }

        public void CreateEvent(Event evnt)
        {
            Repository.Create(evnt);
            Repository.Save();
        }

        public void DeleteEvent(Event evnt)
        {
            Repository.Delete(evnt);
            Repository.Save();
        }

        public void EditEvent(Event evnt, long id)
        {
            var ev = Repository.GetById<Event>(id);

            ev.EventName = evnt.EventName;
            ev.EventDate = evnt.EventDate;
            ev.StartTime = evnt.StartTime;
            ev.EndTime = evnt.EndTime;
            ev.Subject = evnt.Subject;

            Repository.Update(ev);
            Repository.Save();

        }

        public IList<EventDto> GetAllEvents()
        {
            var events = from e in Repository.GetAll<Event>()
                            select new EventDto()
                            {
                                Id = e.Id,
                                EventName = e.EventName,
                                EventDate = e.EventDate,
                                StartTime = e.StartTime,
                                EndTime = e.EndTime,
                                Subject = e.Subject,
                                NumberOfAttendants = e.Employees.Count(),
                                ListOfNames = null
                                        //(from empl in Repository.GetAll<Employee>()
                                        // where e.DepartmentId == d.Id
                                        // select d.DepartmentName).First()
                                
                            };


            return events.ToList();
        }

        public Event GetEvent(long id)
        {
            var result = Repository.GetById<Event>(id);
            return result;
        }

        public EventDto GetEventDto(long id)
        {
            var result = Repository.GetById<Event>(id);
            return MapToDto(result);
        }

        private EventDto MapToDto(Event e)
        {
            return new EventDto()
            {
                Id = e.Id,
                EventName = e.EventName,
                EventDate = e.EventDate,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Subject = e.Subject,
                NumberOfAttendants = e.Employees.Count(),
                ListOfNames = null
            };
        }


    }
}
