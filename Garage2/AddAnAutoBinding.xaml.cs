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
    /// Логика взаимодействия для AddAnAutoBinding.xaml
    /// </summary>
    public partial class AddAnAutoBinding : Page
    {
        private OwnersAndTheirCars _curentOwnersAndTheirCars = new OwnersAndTheirCars();
        public AddAnAutoBinding(OwnersAndTheirCars selectedOwnersAndTheirCars)
        {
            InitializeComponent();
            if (selectedOwnersAndTheirCars != null)
            {
                _curentOwnersAndTheirCars = selectedOwnersAndTheirCars;
            }
            DataContext = _curentOwnersAndTheirCars;
            ComboRegNum.ItemsSource = CarGarageEntities.GetContext().Car.ToList();
            ComboOnwer.ItemsSource = CarGarageEntities.GetContext().CarOwner.ToList();
        }
        private bool CheckingFields()
        {
            var elementWindovForm = new List<string>() { ComboRegNum.Text, ComboOnwer.Text };
            foreach (string elementWindov in elementWindovForm)
                if (elementWindov.Length == 0)
                {
                    return false;
                }
            return true;

        }

        private void SaveAutBinding_Click(object sender, RoutedEventArgs e)
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

                if (_curentOwnersAndTheirCars.idOwnersAndTheirCars_pk_ == 0)
                {
                    CarGarageEntities.GetContext().OwnersAndTheirCars.Add(_curentOwnersAndTheirCars);
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
