using Domain;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IServicePersonalData
    {
        void CreatePersonalData(PersonalData personalData);
        void EditPersonalData(PersonalData personalDataModel, long id);
        void DeletePersonalData(PersonalData personalData);
        IList<PersonalDataDto> GetAllPersonalDatas();
        PersonalDataDto GetPersonalDataDto(long id);
        PersonalData GetPersonalData(long id);
    }
}
