using RKSI.EduPractice_EF_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RKSI.EduPractice_EF_MVVM.ViewModel
{
    class AddCitizenVM : BindableBase
    {
        readonly AddCitizenModel _model = new AddCitizenModel();
        public ReadOnlyObservableCollection<Document> DocumentList => _model.Documents;

        public string name { get; set; }
        public string surname { get; set; }
        public string patronym { get; set; }

        public DelegateCommand AddCitizen { get; }
        public AddCitizenVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };

            AddCitizen = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(name))
                    _model.AddCitizen(name, surname, patronym);
                else
                    Debug.WriteLine("Строки пустые");
            });
        }
    }
}
