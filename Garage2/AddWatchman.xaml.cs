using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garage2
{
    /// <summary>
    /// Логика взаимодействия для AddWatchman.xaml
    /// </summary>
    public partial class AddWatchman : Page
    {
        private Watchman _curentWatchman = new Watchman();
        public AddWatchman(Watchman selectedWatchman)
        {
            InitializeComponent();
            if (selectedWatchman != null)
            {
                _curentWatchman = selectedWatchman;
            }
            DataContext = _curentWatchman;

        }
        private bool CheckingFields()
        {
            var elementWindovForm = new List<string>() { TextBoxNameWatchman.Text, TextBoxSurnameWatchman.Text, TextBoxPatronymicWatchman.Text };
            foreach (string elementWindov in elementWindovForm)
                if (elementWindov.Length == 0)
                {
                    return false;
                }
            return true;

        }

        private void SaveWatchman_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            bool chek = CheckingFields();
            if (chek == false)
            {
                errors.AppendLine("Заполните все поля!");
            }
            else
            {
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                if (_curentWatchman.idWatchman_pk_ == 0)
                {
                    CarGarageEntities.GetContext().Watchman.Add(_curentWatchman);
                }

                try
                {
                    CarGarageEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
