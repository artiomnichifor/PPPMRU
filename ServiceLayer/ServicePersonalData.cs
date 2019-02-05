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
    public class ServicePersonalData : IServicePersonalData
    {
        private IRepository Repository { get; }

        public ServicePersonalData(IRepository repository)
        {
            this.Repository = repository;
        }

        public void CreatePersonalData(PersonalData personalData)
        {
            Repository.Create(personalData);
            Repository.Save();
        }

        public void DeletePersonalData(PersonalData personalData)
        {
            Repository.Delete(personalData);
            Repository.Save();
        }

        public void EditPersonalData(PersonalData personalDataModel, long id)
        {
            var persoanalData = Repository.GetById<PersonalData>(id);

            persoanalData.Adress = personalDataModel.Adress;
            persoanalData.PhoneNumber = personalDataModel.PhoneNumber;
            persoanalData.DateOfBirth = personalDataModel.DateOfBirth;

            Repository.Update<PersonalData>(persoanalData);
            Repository.Save();
        }

        public IList<PersonalDataDto> GetAllPersonalDatas()
        {
            var personalDatas = from p in Repository.GetAll<PersonalData>()
                            select new PersonalDataDto()
                            {
                                Id = p.Id,
                                Adress = p.Adress,
                                PhoneNumber = p.PhoneNumber,
                                DateOfBirth = p.DateOfBirth
                            };

            return personalDatas.ToList();
        }

        public PersonalData GetPersonalData(long id)
        {
            var result = Repository.GetById<PersonalData>(id);
            return result;
        }

        public PersonalDataDto GetPersonalDataDto(long id)
        {
            var result = Repository.GetById<PersonalData>(id);
            return MapToDto(result);
        }

        private PersonalDataDto MapToDto(PersonalData p)
        {
            return new PersonalDataDto()
            {
                Id = p.Id,
                Adress = p.Adress,
                PhoneNumber = p.PhoneNumber,
                DateOfBirth = p.DateOfBirth
            };
        }

    }
}
