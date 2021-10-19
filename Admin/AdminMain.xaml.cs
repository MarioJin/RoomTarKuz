using RoomTarKuz.Helper;
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

namespace RoomTarKuz.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        public AdminMain()
        {
            InitializeComponent();
        }

        private void btnListProduct_Click(object sender, RoutedEventArgs e)
        {
            frmMainAdmin.Navigate(new AdminPageProduct());
        }

        private void btnListUser_Click(object sender, RoutedEventArgs e)
        {
            frmMainAdmin.Navigate(new AdminPageUser());
        }

        private void btnListExitProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void btnListCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
