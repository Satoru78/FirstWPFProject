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
using WpfCarsApp.Context;
using WpfCarsApp.Model;

namespace WpfCarsApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = DateApp.ce.Cars.ToList(); 
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView.ItemsSource = DateApp.ce.Cars.Where(item => item.Brand.Contains(Search.Text) || item.YearIssue.Contains(Search.Text) ||
            item.Mileage.ToString().Contains(Search.Text) || item.Price.ToString().Contains(Search.Text)).ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ActionPage(new Model.Cars()));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Cars)DataView.SelectedItem;
            if (selectedItem != null)
            {
                NavigationService.Navigate( new ActionPage(selectedItem));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Cars)DataView.SelectedItem;
            if (selectedItem != null)
            {
                DateApp.ce.Cars.Remove(selectedItem);
                DateApp.ce.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Data deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
