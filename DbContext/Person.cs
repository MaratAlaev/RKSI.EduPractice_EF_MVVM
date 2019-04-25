using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKSI.EduPractice_EF_MVVM
{
    public class Person
    {
        public int Id { get; set; }
        public int Cypher { get; set; }
        public int Inn { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }

        public override string ToString()
        {
            return $"Шифр: {Cypher}, ИНН: {Inn}, Тип: {Type}, Дата рег.: {Date.ToShortDateString()}";
        }
    }
}
