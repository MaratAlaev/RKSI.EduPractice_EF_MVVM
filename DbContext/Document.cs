using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKSI.EduPractice_EF_MVVM
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Serial { get; set; }
        public string WhereIssued { get; set; }
        public DateTime DateIssued { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }

        public override string ToString()
        {
            return Name + " " + Serial;
        }
    }
}
