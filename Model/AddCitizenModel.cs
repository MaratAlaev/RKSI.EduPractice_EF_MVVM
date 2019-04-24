using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class AddCitizenModel : BindableBase
    {
        private ObservableCollection<Document> _documents = new ObservableCollection<Document>();
        public ReadOnlyObservableCollection<Document> Documents;
        public AddCitizenModel()
        {
            using (var db = new CitizenDbContext())
            {
                Documents = new ReadOnlyObservableCollection<Document>(_documents);
                _documents.AddRange(db.Documents);
            }
        }

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
