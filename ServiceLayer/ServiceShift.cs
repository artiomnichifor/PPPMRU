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
    public class ServiceShift : IServiceShift
    {
        private IRepository Repository { get; }

        public ServiceShift(IRepository repository)
        {
            this.Repository = repository;
        }

        public void CreateShift(Shift shift)
        {
            Repository.Create(shift);
            Repository.Save();
        }

        public void DeleteShift(Shift shift)
        {
            Repository.Delete(shift);
            Repository.Save();

        }

        public void EditShift(Shift shiftModel, long id)
        {
            var shift = Repository.GetById<Shift>(id);

            shift.ShiftName = shiftModel.ShiftName;
            shift.StartTime = shiftModel.StartTime;
            shift.EndTime = shiftModel.EndTime;
            shift.BreakTime = shiftModel.BreakTime;

            Repository.Update<Shift>(shift);
            Repository.Save();
        }


        public IList<ShiftDto> GetAllShifts()
        {
            var shifts = from s in Repository.GetAll<Shift>()
                            select new ShiftDto()
                            {
                                Id = s.Id,
                                ShiftName = s.ShiftName,
                                StartTime = s.StartTime,
                                EndTime = s.EndTime,
                                BreakTime = s.BreakTime
                            };


            return shifts.ToList();
        }

        public Shift GetShift(long id)
        {
            var result = Repository.GetById<Shift>(id);
            return result;
        }

        public ShiftDto GetShiftDto(long id)
        {
            var result = Repository.GetById<Shift>(id);
            return MapToDto(result);
        }

        private ShiftDto MapToDto(Shift s)
        {
            return new ShiftDto()
            {
                Id = s.Id,
                ShiftName = s.ShiftName,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                BreakTime = s.BreakTime
            };
        }
    }
}
