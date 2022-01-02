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
    /// Логика взаимодействия для ActionPage.xaml
    /// </summary>
    public partial class ActionPage : Page
    {
        public Cars Cars { get; set; }
        public ActionPage(Cars cars)
        {
            InitializeComponent();
            Cars = cars;
            this.DataContext = this;
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.ID == 0)
            {
                DateApp.ce.Cars.Add(Cars);
            }
            DateApp.ce.SaveChanges();
            MessageBox.Show("Data add", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
    }
}
