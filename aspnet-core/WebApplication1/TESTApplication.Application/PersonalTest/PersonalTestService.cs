using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTApplication.PersonalTest
{
    public class PersonalTestService : IPersonalTestService
    {
        private readonly IPersonalRepository _personalRepository;
        public PersonalTestService(IPersonalRepository personalRepository) 
        {
            this._personalRepository = personalRepository;
        }

        public async Task<List<PersonalDTO>> GetPersonal() 
        {
            var result = new List<PersonalDTO>();
            try
            {
                // se puede utilizar automapper para definir 1 vez la regla de mapeo entre entidades
                var data = await _personalRepository.GetPersonal();

                result = data.Select(p => new PersonalDTO
                {
                    Id = p.PersonId,
                    FullName = p.Name,
                    Address = p.FullAddress,
                    Email = p.EmailAddress,
                    Phone = p.Phone
                })
                .ToList();

                return result;
            }
            catch
            {
                return result;
            }
        }

        public async Task<PersonalDTO?> AddPersonal(PersonalDTO input) 
        {
            try 
            {
                var inputData = new Personal 
                {
                    Name = input.FullName,
                    FullAddress = input.Address,
                    EmailAddress = input.Email,
                    Phone = input.Phone
                };
                var data = await _personalRepository.AddPersonal(inputData);

                if (data == null) return null;

                return new PersonalDTO 
                {
                    Id = data.PersonId,
                    FullName = data.Name,
                    Phone = data.Phone,
                    Address = data.FullAddress,
                    Email = data.EmailAddress,
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<PersonalDTO?> UpdatePersonal(PersonalDTO input) 
        {
            try
            {
                var inputData = new Personal
                {
                    PersonId = input.Id,
                    EmailAddress = input.Email,
                    Phone = input.Phone
                };
                var data = await _personalRepository.UpdatePersonal(inputData);

                if(data == null) return null;

                return new PersonalDTO 
                {
                    Id = input.Id,
                    Address = data.FullAddress,
                    Email = data.EmailAddress,
                    Phone = data.Phone,
                    FullName = data.Name
                };
            }
            catch 
            {
                return null;
            }
        }

        public async Task<bool> DeletePersonal(int id) 
        {
            try
            {
                var result = await _personalRepository.DeletePersonal(id);
                return result;
            }
            catch {
                return false;
            }
        }
    }
}
