using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

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

        public void SaveToJSON(ReadOnlyObservableCollection<Citizen> citizens,
            ReadOnlyObservableCollection<Person> persons, ReadOnlyObservableCollection<Document> documents)
        {
            if (!Directory.Exists("db"))
            {
                Directory.CreateDirectory("db");
            }
            XmlSerializer ser = new XmlSerializer(typeof(ComboCitizen));

            foreach (var ctz in Citizens)
            {
                try
                {
                    var person = (from i in persons where i.CitizenId == ctz.Id select i).First();
                    var citizen = (from i in citizens where i.Id == ctz.Id select i).First();
                    var document = (from i in documents where i.CitizenId == ctz.Id select i).First();
                    ComboCitizen c = new ComboCitizen(citizen, person, document);
                    using (FileStream fs = new FileStream("db/" + ctz + ".json", FileMode.Create))
                    {
                        ser.Serialize(fs, c);
                    }
                }
                catch (Exception) { }
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
