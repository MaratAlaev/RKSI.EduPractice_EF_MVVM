using System.Windows;

namespace RKSI.EduPractice_EF_MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для EditCitizenWindow.xaml
    /// </summary>
    public partial class EditCitizenWindow : Window
    {
        public EditCitizenWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
