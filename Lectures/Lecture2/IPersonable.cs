using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture2
{
    public interface IPersonable
    {
        void CreatePerson(int id);

        void DeletePerson(PersonStruct person);
    }
}
