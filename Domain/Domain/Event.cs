using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event : EntityBase
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        private Event()
        {

        }

        public Event(string eventName, DateTime eventDate, TimeSpan startTime, TimeSpan endTime, string subject)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException($"{nameof(eventName)} is null or empty");
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException($"{nameof(subject)} is null or empty");
            if (EventDate == null)
                throw new ArgumentException($"{nameof(EventDate)} is null");
            if (startTime == null)
                throw new ArgumentException($"{nameof(startTime)} is null");
            if (endTime == null)
                throw new ArgumentException($"{nameof(endTime)} is null");

            this.EventName = eventName;
            this.EventDate = EventDate;
            this.StartTime = startTime;
            this.EndTime = EndTime;
            this.Subject = subject;
        }
    }
}
