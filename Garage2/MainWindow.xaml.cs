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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new GarageTable());
            Manager.MainFrame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void AddOnwer_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOnwer(null));
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddingACar(null));
        }

        private void AddWatchman_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddWatchman(null));
        }

        private void LinkTheCarToTheOwner_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LinkingTheMachine(null));
        }
    }
}
