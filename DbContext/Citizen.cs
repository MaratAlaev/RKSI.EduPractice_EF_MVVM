using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RKSI.EduPractice_EF_MVVM
{
    [Serializable]
    public class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }
        public List<Person> People { get; set; }
        public List<Document> Documents { get; set; }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronym;
        }
    }
}
