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
    /// Логика взаимодействия для AddingAGarage.xaml
    /// </summary>
    public partial class AddingAGarage : Page
    {
        private Garage _curentGarage = new Garage();
        public AddingAGarage(Garage selectedGarage)
        {
            InitializeComponent();
            if (selectedGarage != null)
            {
                _curentGarage = selectedGarage;
            }
            DataContext = _curentGarage;
            ComboOnwer.ItemsSource = CarGarageEntities.GetContext().CarOwner.ToList();
            ComboWatchman.ItemsSource = CarGarageEntities.GetContext().Watchman.ToList();
            ComboWatchman1.ItemsSource = CarGarageEntities.GetContext().Watchman.ToList();

        }
        private bool CheckingFields()
        {
            var elementWindovForm = new List<string>() { ComboOnwer.Text, ComboWatchman.Text, ComboWatchman1.Text, TexBoxDateOfPuttingTheCarInTheGarage.Text, TexBoxDateOfTakingTheCarIntoTheGarage.Text };
            foreach (string elementWindov in elementWindovForm)
                if (elementWindov.Length == 0)
                {
                    return false;
                }
            return true;

        }

        private void SaveCar_Click(object sender, RoutedEventArgs e)
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

                if (_curentGarage.idGarage_pk_ == 0)
                {
                    CarGarageEntities.GetContext().Garage.Add(_curentGarage);
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
