using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class AddCitizenModel : BindableBase
    {
        public void AddCitizen(string name, string surname, string patronym)
        {
            if (!(string.IsNullOrEmpty(name) && string.IsNullOrWhiteSpace(name))
                &&
                !(string.IsNullOrEmpty(surname) && string.IsNullOrWhiteSpace(surname))
                &&
                !(string.IsNullOrEmpty(patronym) && string.IsNullOrWhiteSpace(patronym)))
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
            else
            {
                throw new System.InvalidOperationException("Fields are empty");
            }
        }
    }
}
