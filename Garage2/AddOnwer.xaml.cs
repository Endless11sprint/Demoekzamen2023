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
    /// Логика взаимодействия для AddOnwer.xaml
    /// </summary>
    public partial class AddOnwer : Page
    {
        private CarOwner _curentCarOwner = new CarOwner();
        public AddOnwer(CarOwner selectedCarOwner)
        {
            InitializeComponent();
            _curentCarOwner = selectedCarOwner;
            if (selectedCarOwner != null)
            {
                _curentCarOwner = selectedCarOwner;
            }
            DataContext = _curentCarOwner;
        }
        private bool CheckingFields()
        {
            var elementWindovForm = new List<string>() { TextBoxNameOwner.Text, TextBoxSurnameOwner.Text, TextBoxPatronymicOwner.Text, TextBoxPhoneNumberOwner.Text };
            foreach (string elementWindov in elementWindovForm)
                if (elementWindov.Length == 0)
                {
                    return false;
                }
            return true;

        }
        private void SaveOwner_Click(object sender, RoutedEventArgs e)
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

                if (_curentCarOwner.idCarOwner_pk_ == 0)
                {
                    CarGarageEntities.GetContext().CarOwner.Add(_curentCarOwner);
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
