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
    /// Логика взаимодействия для LinkingTheMachine.xaml
    /// </summary>
    public partial class LinkingTheMachine : Page
    {
        private OwnersAndTheirCars _curentOwnersAndTheirCars = new OwnersAndTheirCars();
        public LinkingTheMachine(OwnersAndTheirCars selectedOwnersAndTheirCars)
        {
            InitializeComponent();
            DGInformationAboutOwnersAndTheirCars.ItemsSource = CarGarageEntities.GetContext().OwnersAndTheirCars.ToList();
            _curentOwnersAndTheirCars = selectedOwnersAndTheirCars;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var WorkInTheOwnersAndTheirCars = DGInformationAboutOwnersAndTheirCars.SelectedItems.Cast<OwnersAndTheirCars>().ToList();
            if (MessageBox.Show($"Вы точно хоите удалить следущие {WorkInTheOwnersAndTheirCars.Count()} элементов?", "Внимание!"
                , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CarGarageEntities.GetContext().OwnersAndTheirCars.RemoveRange(WorkInTheOwnersAndTheirCars);
                    CarGarageEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGInformationAboutOwnersAndTheirCars.ItemsSource = CarGarageEntities.GetContext().OwnersAndTheirCars.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAnAutoBinding(null));
        }

        private void DGInformationAboutOwnersAndTheirCars_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                CarGarageEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGInformationAboutOwnersAndTheirCars.ItemsSource = CarGarageEntities.GetContext().OwnersAndTheirCars.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAnAutoBinding((sender as Button).DataContext as OwnersAndTheirCars));
        }
    }
}
