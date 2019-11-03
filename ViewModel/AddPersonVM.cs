using Prism.Commands;
using Prism.Mvvm;
using RKSI.EduPractice_EF_MVVM.Model;
using RKSI.EduPractice_EF_MVVM.View;
using System;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.ViewModel
{
    class AddPersonVM : BindableBase
    {
        private AddPersonModel _model = new AddPersonModel();
        public ReadOnlyObservableCollection<Citizen> Citizens => _model.Citizens;
        public int? Cypher { get; set; }
        public int? Inn { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string DefaultDate => DateTime.Now.ToShortDateString();
        public Citizen SelectedCitizen { get; set; }

        public DelegateCommand AddPerson { get; }

        public AddPersonVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
            AddPerson = new DelegateCommand(() =>
            {
                try
                {
                    _model.AddPerson(Cypher.Value, Inn.Value, Type, Date, SelectedCitizen);
                }
                catch (InvalidOperationException)
                {
                    System.Windows.MessageBox.Show("Поля необходимо заполнить", "Ошибка");
                }
            });
        }
    }
}
