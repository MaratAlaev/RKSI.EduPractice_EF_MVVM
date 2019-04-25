using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class AddPersonModel : BindableBase
    {
        public ReadOnlyObservableCollection<Citizen> Citizens { get; }

        public AddPersonModel()
        {
            using(var db = new CitizenDbContext())
            {
                ObservableCollection<Citizen> citizens = new ObservableCollection<Citizen>(db.Citizens);
                Citizens = new ReadOnlyObservableCollection<Citizen>(citizens);
            }
        }

        public void AddPerson(int cypher, int inn, string type, DateTime date, Citizen ctz)
        {
            Person prs = new Person()
            {
                Cypher = cypher,
                Inn = inn,
                Type = type,
                Date = date,
                CitizenId = ctz.Id
            };
            using (var db = new CitizenDbContext())
            {
                db.Persons.Add(prs);
                db.SaveChanges();
            }
        }
    }
}
