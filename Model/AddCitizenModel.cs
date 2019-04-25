using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class AddCitizenModel : BindableBase
    {
        public void AddCitizen(string name, string surname, string patronym)
        {
            Citizen ctz = new Citizen()
            {
                Name = name,
                Surname = surname,
                Patronym = patronym
            };
            using (var db = new CitizenDbContext())
            {
                db.Citizens.Add(ctz);
                db.SaveChanges();
            }
        }
    }
}
