using Prism.Commands;
using Prism.Mvvm;
using RKSI.EduPractice_EF_MVVM.Model;
using RKSI.EduPractice_EF_MVVM.View;

namespace RKSI.EduPractice_EF_MVVM.ViewModel
{
    class EditCitizenVM : BindableBase
    {
        private EditCitizenModel _model = new EditCitizenModel();
        public DelegateCommand EditCitizen { get; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronym { get; set; }

        public EditCitizenVM()
        {
            _model.PropertyChanged += (sender, args) => { RaisePropertyChanged(args.PropertyName); };
        }
    }
}
