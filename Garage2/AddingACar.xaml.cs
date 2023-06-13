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
    /// Логика взаимодействия для AddingACar.xaml
    /// </summary>
    public partial class AddingACar : Page
    {
        private Car _curentCar = new Car();
        public AddingACar(Car selectedCar)
        {
            InitializeComponent();
            if (selectedCar != null)
            {
                _curentCar = selectedCar;
            }
            DataContext = _curentCar;
        }
        private bool CheckingFields()
        {
            var elementWindovForm = new List<string>() { TextBoxRegNum.Text, TexBoxModel.Text };
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

                if (_curentCar.idCar_pk_ == 0)
                {
                    CarGarageEntities.GetContext().Car.Add(_curentCar);
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
