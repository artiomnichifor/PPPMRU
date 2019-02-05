using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shift : EntityBase
    {
        public string ShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan BreakTime { get; set; }

        public Shift()
        {

        }
        public Shift(string shiftName, TimeSpan startTime, TimeSpan endTime, TimeSpan breakTime)
        {
            if (string.IsNullOrWhiteSpace(shiftName))
                throw new ArgumentException($"{nameof(shiftName)} is null or empty");
            if (startTime == null)
                throw new ArgumentException($"{nameof(startTime)} is null");
            if (endTime == null)
                throw new ArgumentException($"{nameof(endTime)} is null");
            if (breakTime == null)
                throw new ArgumentException($"{nameof(breakTime)} is null");

            this.ShiftName = shiftName;
            this.StartTime = startTime;
            this.EndTime = EndTime;
            this.BreakTime = breakTime;
        }

        public Shift(long id, string shiftName, TimeSpan startTime, TimeSpan endTime, TimeSpan breakTime)
        {
            if (string.IsNullOrWhiteSpace(shiftName))
                throw new ArgumentException($"{nameof(shiftName)} is null or empty");
            if (startTime == null)
                throw new ArgumentException($"{nameof(startTime)} is null");
            if (endTime == null)
                throw new ArgumentException($"{nameof(endTime)} is null");
            if (breakTime == null)
                throw new ArgumentException($"{nameof(breakTime)} is null");

            this.Id = id;
            this.ShiftName = shiftName;
            this.StartTime = startTime;
            this.EndTime = EndTime;
            this.BreakTime = breakTime;
        }

        public virtual Employee Employee { get; set; }
    }
}
