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
    /// Логика взаимодействия для GarageTable.xaml
    /// </summary>
    public partial class GarageTable : Page
    {
        private Garage _curentOwnersGarage = new Garage();
        public GarageTable()
        {
            InitializeComponent();
            DGridGarageTable.ItemsSource = CarGarageEntities.GetContext().Garage.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var WorkInTheGarage = DGridGarageTable.SelectedItems.Cast<Garage>().ToList();
            if (MessageBox.Show($"Вы точно хоите удалить следущие {WorkInTheGarage.Count()} элементов?", "Внимание!"
                , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CarGarageEntities.GetContext().Garage.RemoveRange(WorkInTheGarage);
                    CarGarageEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridGarageTable.ItemsSource = CarGarageEntities.GetContext().Garage.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddingAGarage(null));
        }

        private void DGridGarageTable_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            if (Visibility == Visibility.Visible)
            {
                CarGarageEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridGarageTable.ItemsSource = CarGarageEntities.GetContext().Garage.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddingAGarage((sender as Button).DataContext as Garage));

        }
    }
}
