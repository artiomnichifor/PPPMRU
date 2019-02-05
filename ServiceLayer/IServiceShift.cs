using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServiceShift
    {
        void CreateShift(Shift shift);
        void EditShift(Shift shiftModel, long id);
        void DeleteShift(Shift shift);
        IList<ShiftDto> GetAllShifts();
        ShiftDto GetShiftDto(long id);
        Shift GetShift(long id);
    }
}
