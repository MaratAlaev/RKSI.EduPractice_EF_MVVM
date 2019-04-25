using System.Windows;
using System.Linq;
using System;

namespace RKSI.EduPractice_EF_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для FindByCypherWindow.xaml
    /// </summary>
    public partial class FindByCypherWindow : Window
    {
        public FindByCypherWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CitizenDbContext())
            {
                if (int.TryParse(tbCypher.Text, out int cypherToFind))
                {
                    try
                    {
                        var person = (from i in db.Persons where i.Cypher == cypherToFind select i).First();
                        var citizen = (from i in db.Citizens where i.Id == person.CitizenId select i).First();
                        var document = (from i in db.Documents where i.CitizenId == person.CitizenId select i).First();
                        MessageBox.Show(citizen + "\n" + person + "\n" + document);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ничего не найдено");
                    }
                }
            }
        }
    }
}
