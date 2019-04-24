using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class EditCitizenModel : BindableBase
    {
        //не используется
        public void EditCitizen(string name, string surname, string patronym)
        {
            using (var db = new CitizenDbContext())
            {
                Citizen ctz = new Citizen()
                {
                    Name = name,
                    Surname = surname,
                    Patronym = patronym
                };
                var citizen = (from i in db.Citizens where i.Id == ctz.Id select i).First();
                citizen.Name = ctz.Name;
                citizen.Surname = ctz.Surname;
                citizen.Patronym = ctz.Patronym;
                db.SaveChanges();
                Debug.WriteLine("Изменение завершено");
            }
        }
    }
}
