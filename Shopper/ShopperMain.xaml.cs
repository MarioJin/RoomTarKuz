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
using System.Windows.Shapes;

namespace RoomTarKuz.Shopper
{
    /// <summary>
    /// Логика взаимодействия для ShopperMain.xaml
    /// </summary>
    public partial class ShopperMain : Window
    {
        public ShopperMain()
        {
            InitializeComponent();
        }

        private void btnListProduct_Click(object sender, RoutedEventArgs e)
        {
            frmMainShopper.Navigate(new ShopperPageProduct());
        }

        private void btnListBasket_Click(object sender, RoutedEventArgs e)
        {
            frmMainShopper.Navigate(new ShopperPageBasket());
        }

        private void btnListProfile_Click(object sender, RoutedEventArgs e)
        {
            frmMainShopper.Navigate(new ProfilePage());
        }

        private void btnListCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnListExitProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void btnListCompany_Click(object sender, RoutedEventArgs e)
        {
            frmMainShopper.Navigate(new CompanyPage());
        }
    }
}
