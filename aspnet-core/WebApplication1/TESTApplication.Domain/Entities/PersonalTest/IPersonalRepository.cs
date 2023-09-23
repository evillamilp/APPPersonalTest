using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTApplication.PersonalTest
{
    public interface IPersonalRepository
    {
        Task<List<Personal>> GetPersonal();
        Task<Personal?> AddPersonal(Personal input);
        Task<Personal?> UpdatePersonal(Personal input);
        Task<bool> DeletePersonal(int id);

    }
}
