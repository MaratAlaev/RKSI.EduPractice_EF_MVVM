using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKSI.EduPractice_EF_MVVM
{
    public class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public List<Person> People { get; set; }
        public List<Document> Documents { get; set; }
    }
}
