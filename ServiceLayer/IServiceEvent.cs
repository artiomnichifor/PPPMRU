using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServiceEvent
    {
        void CreateEvent(Event evnt);
        void EditEvent(Event evnt, long id);
        void DeleteEvent(Event evnt);
        IList<EventDto> GetAllEvents();
        EventDto GetEventDto(long id);
        Event GetEvent(long id);
    }
}
