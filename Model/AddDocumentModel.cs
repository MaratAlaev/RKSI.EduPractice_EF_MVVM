using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKSI.EduPractice_EF_MVVM.Model
{
    class AddDocumentModel : BindableBase
    {
        public ReadOnlyObservableCollection<Citizen> Citizens { get; }

        public AddDocumentModel()
        {
            using (var db = new CitizenDbContext())
            {
                ObservableCollection<Citizen> citizens = new ObservableCollection<Citizen>(db.Citizens);
                Citizens = new ReadOnlyObservableCollection<Citizen>(citizens);
            }
        }

        public void AddDocument(string name, int? serial, string whereIssued, DateTime date, Citizen ctz)
        {
            Document doc = new Document()
            {
                Name = name,
                Serial = serial.Value,
                WhereIssued = whereIssued,
                DateIssued = date,
                CitizenId = ctz.Id
            };
            using (var db = new CitizenDbContext())
            {
                db.Documents.Add(doc);
                db.SaveChanges();
            }
        }
    }
}
