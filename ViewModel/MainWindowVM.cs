using Prism.Commands;
using Prism.Mvvm;
using RKSI.EduPractice_EF_MVVM.Model;
using RKSI.EduPractice_EF_MVVM.View;
using System.Collections.ObjectModel;
using System.Linq;

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

        public DelegateCommand AddCitizen { get; }
        public DelegateCommand RefreshCitizenTable { get; }
        public DelegateCommand EditCitizen { get; }
        public DelegateCommand DeleteCitizen { get; }

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
                //EditCitizenWindow ecw = new EditCitizenWindow();
                //ecw.DataContext = SelectedCitizen;
                //Citizen ctz = SelectedCitizen;
                //if (ecw.ShowDialog() == true)
                //{
                //    using (var db = new CitizenDbContext())
                //    {
                //        var citizen = (from i in db.Citizens where i.Id == ctz.Id select i).First();
                //        citizen.Name = ctz.Name;
                //        citizen.Surname = ctz.Surname;
                //        citizen.Patronym = ctz.Patronym;
                //        db.SaveChanges();
                //    }
                //    _model.RefreshTables();
                //}
                EditCitizenVM ecw = new EditCitizenVM();
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
        }
    }
}
