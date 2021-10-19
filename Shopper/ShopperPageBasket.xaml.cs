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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoomTarKuz.Shopper
{
    /// <summary>
    /// Логика взаимодействия для ShopperPageBasket.xaml
    /// </summary>
    public partial class ShopperPageBasket : Page
    {
        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        List<Basket> listBasket = new List<Basket>();
        private int numPage = 0; 

        public ShopperPageBasket()
        {
            InitializeComponent();

        }

        private void LvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBasket.Where
                (i => i.IdUser == listBasket[LvProduct.SelectedIndex].IdUser);
        }

        private void btnBackFrm_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            if (numPage > 0)
            {
                numPage--;
                tbckPage.Text = (numPage + 1).ToString();
            }
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (listBasket.Count > 0)
            {
                numPage++;
                tbckPage.Text = (numPage + 1).ToString();
            }
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
