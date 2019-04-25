using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKSI.EduPractice_EF_MVVM
{
    [Serializable]
    public class ComboCitizen
    {
        public ComboCitizen()
        {

        }

        public ComboCitizen(Citizen ctz, Person prs, Document doc)
        {
            Id = ctz.Id;
            Name = ctz.Name;
            Surname = ctz.Surname;
            Patronym = ctz.Patronym;

            PersId = prs.Id;
            Cypher = prs.Cypher;
            Inn = prs.Inn;
            Type = prs.Type;
            Date = prs.Date;

            DocId = doc.Id;
            DocName = doc.Name;
            Serial = doc.Serial;
            WhereIssued = doc.WhereIssued;
            DateIssued = doc.DateIssued;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }

        public int DocId { get; set; }
        public string DocName { get; set; }
        public int Serial { get; set; }
        public string WhereIssued { get; set; }
        public DateTime DateIssued { get; set; }

        public int PersId { get; set; }
        public int Cypher { get; set; }
        public int Inn { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname + " " + Patronym + " " + Cypher;
        }
    }
}
