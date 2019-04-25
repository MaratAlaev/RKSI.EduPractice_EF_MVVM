using Prism.Commands;
using Prism.Mvvm;
using RKSI.EduPractice_EF_MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace RKSI.EduPractice_EF_MVVM.ViewModel
{
    class AddDocumentVM : BindableBase
    {
        private AddDocumentModel _model = new AddDocumentModel();
        public ReadOnlyObservableCollection<Citizen> Citizens => _model.Citizens;
        public string Name { get; set; }
        public int? Serial { get; set; }
        public string WhereIssued { get; set; }
        public DateTime DateIssued { get; set; }
        public string DefaultDate => DateTime.Now.ToShortDateString();
        public Citizen SelectedCitizen { get; set; }

        public DelegateCommand AddDocument { get; }

        public AddDocumentVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
            AddDocument = new DelegateCommand(() =>
            {
                _model.AddDocument(Name, Serial.Value, WhereIssued, DateIssued, SelectedCitizen);
            });
        }
    }
}
