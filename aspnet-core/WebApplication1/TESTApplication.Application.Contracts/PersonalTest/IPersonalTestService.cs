using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTApplication.PersonalTest
{
    public interface IPersonalTestService
    {
        Task<List<PersonalDTO>> GetPersonal();
        Task<PersonalDTO?> AddPersonal(PersonalDTO input);
        Task<PersonalDTO?> UpdatePersonal(PersonalDTO input);
        Task<bool> DeletePersonal(int id);
    }
}
