using Prism.Commands;
using Prism.Mvvm;
using RKSI.EduPractice_EF_MVVM.Model;
using RKSI.EduPractice_EF_MVVM.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RKSI.EduPractice_EF_MVVM.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        readonly MainWindowModel _model = new MainWindowModel();
        public ReadOnlyObservableCollection<Citizen> Citizens => _model.Citizens;
        public ReadOnlyObservableCollection<Person> Persons => _model.Persons;
        public ReadOnlyObservableCollection<Document> Documents => _model.Documents;

        public Citizen SelectedCitizen { get; set; }
        public Person SelectedPerson { get; set; }
        public Document SelectedDocument { get; set; }

        public DelegateCommand RefreshCitizenTable { get; }
        public DelegateCommand AddCitizen { get; }
        public DelegateCommand EditCitizen { get; }
        public DelegateCommand DeleteCitizen { get; }
        public DelegateCommand AddPerson { get; }
        public DelegateCommand EditPerson { get; }
        public DelegateCommand DeletePerson { get; }
        public DelegateCommand AddDocument { get; }
        public DelegateCommand EditDocument { get; }
        public DelegateCommand DeleteDocument { get; }
        public DelegateCommand FindByCypher { get; }
        public DelegateCommand SaveToJSON { get; }

        public MainWindowVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };

            RefreshCitizenTable = new DelegateCommand(() =>
            {
                _model.RefreshTables();
            });

            AddCitizen = new DelegateCommand(() =>
            {
                AddCitizenWindow acw = new AddCitizenWindow();
                acw.ShowDialog();
                _model.RefreshTables();
            });

            EditCitizen = new DelegateCommand(() =>
            {
                EditCitizenWindow ecw = new EditCitizenWindow();
                ecw.DataContext = SelectedCitizen;
                Citizen ctz = SelectedCitizen;
                if (ecw.ShowDialog() == true)
                {
                    using (var db = new CitizenDbContext())
                    {
                        var citizen = (from i in db.Citizens where i.Id == ctz.Id select i).First();
                        citizen.Name = ctz.Name;
                        citizen.Surname = ctz.Surname;
                        citizen.Patronym = ctz.Patronym;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeleteCitizen = new DelegateCommand(() =>
            {
                using (var db = new CitizenDbContext())
                {
                    var citizen = (from i in db.Citizens where i.Id == SelectedCitizen.Id select i).First();
                    db.Citizens.Remove(citizen);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            AddPerson = new DelegateCommand(() =>
            {
                AddPersonWindow apw = new AddPersonWindow();
                apw.ShowDialog();
                _model.RefreshTables();
            });

            EditPerson = new DelegateCommand(() =>
            {
                EditPersonWindow epw = new EditPersonWindow();
                Person prs = SelectedPerson;
                epw.DataContext = prs;
                if (epw.ShowDialog() == true)
                {
                    using (var db = new CitizenDbContext())
                    {
                        var person = (from i in db.Persons where i.Id == prs.Id select i).First();
                        person.Cypher = prs.Cypher;
                        person.Inn = prs.Inn;
                        person.Type = prs.Type;
                        person.Date = prs.Date;
                        person.CitizenId = prs.CitizenId;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeletePerson = new DelegateCommand(() =>
            {
                using (var db = new CitizenDbContext())
                {
                    var person = (from i in db.Persons where i.Id == SelectedPerson.Id select i).First();
                    db.Persons.Remove(person);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            AddDocument = new DelegateCommand(() =>
            {
                AddDocumentWindow adw = new AddDocumentWindow();
                adw.ShowDialog();
                _model.RefreshTables();
            });

            EditDocument = new DelegateCommand(() =>
            {
                EditDocumentWindow edw = new EditDocumentWindow();
                Document doc = SelectedDocument;
                edw.DataContext = doc;
                if (edw.ShowDialog() == true)
                {
                    using (var db = new CitizenDbContext())
                    {
                        var document = (from i in db.Documents where i.Id == doc.Id select i).First();
                        document.Name = doc.Name;
                        document.Serial = doc.Serial;
                        document.WhereIssued = doc.WhereIssued;
                        document.DateIssued = doc.DateIssued;
                        document.CitizenId = doc.CitizenId;
                        db.SaveChanges();
                    }
                    _model.RefreshTables();
                }
            });

            DeleteDocument = new DelegateCommand(() =>
            {
                using (var db = new CitizenDbContext())
                {
                    var document = (from i in db.Documents where i.Id == SelectedDocument.Id select i).First();
                    db.Documents.Remove(document);
                    db.SaveChanges();
                }
                _model.RefreshTables();
            });

            FindByCypher = new DelegateCommand(() =>
            {
                FindByCypherWindow fbc = new FindByCypherWindow();
                fbc.Show();
            });

            SaveToJSON = new DelegateCommand(() =>
            {
                _model.SaveToJSON(Citizens, Persons, Documents);
                MessageBox.Show("Все сохранено");
            });
        }
    }
}
