using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class MainWindowModel : BindableBase
    {
        private readonly ObservableCollection<Citizen> _citizens = new ObservableCollection<Citizen>();
        public readonly ReadOnlyObservableCollection<Citizen> Citizens;
        private readonly ObservableCollection<Person> _persons = new ObservableCollection<Person>();
        public readonly ReadOnlyObservableCollection<Person> Persons;
        private readonly ObservableCollection<Document> _documents = new ObservableCollection<Document>();
        public readonly ReadOnlyObservableCollection<Document> Documents;

        public MainWindowModel()
        {
            Citizens = new ReadOnlyObservableCollection<Citizen>(_citizens);
            Persons = new ReadOnlyObservableCollection<Person>(_persons);
            Documents = new ReadOnlyObservableCollection<Document>(_documents);

            using (var db = new CitizenDbContext())
            {
                _citizens.AddRange(db.Citizens);
                _persons.AddRange(db.Persons);
                _documents.AddRange(db.Documents);
            }
        }

        public void AddCitizen(Citizen ctz)
        {
            if (ctz != null)
            {
                _citizens.Add(ctz);
                using (var db = new CitizenDbContext())
                {
                    db.Citizens.Add(ctz);
                    db.SaveChanges();
                }
            }
        }

        public void RefreshTables()
        {
            _citizens.Clear();
            _persons.Clear();
            _documents.Clear();

            using (var db = new CitizenDbContext())
            {
                _citizens.AddRange(db.Citizens);
                _persons.AddRange(db.Persons);
                _documents.AddRange(db.Documents);
            }
        }
    }
}
