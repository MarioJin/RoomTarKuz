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
        List<ProdBasket> listBasket = new List<ProdBasket>();
        private int numPage = 0;


        List<string> listSort = new List<string>()
        {
            "Наименование (по возрастанию)",
            "Наименование (по убыванию)",
            "Стоимость (по возрастанию)",
            "Стоимость (по убыванию)"
        };
        List<string> listFiltr = new List<string>();

        public ShopperPageBasket()
        {
            InitializeComponent();

            LvBasket.ItemsSource = DB.ProdBasket.Where(i => i.IdUser == ClassUserId.Instance.idUserInt).ToList();
            var category = DB.Category.ToList();
            foreach (var i in category)
            {
                listFiltr.Add(i.NameCategory);
            }
            listFiltr.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = listFiltr;
            cmbFiltrationCategory.SelectedIndex = 0;

            cmbSortingPrice.ItemsSource = listSort;
            cmbSortingPrice.SelectedIndex = 0;

        }

        void Filtr()
        {
            listBasket = DB.ProdBasket.ToList();

            var selectSort = cmbSortingPrice.SelectedIndex;
            switch (selectSort)
            {
                case 0:
                    listBasket = listBasket.OrderBy(i => i.NameProduct).ToList();
                    break;
                case 1:
                    listBasket = listBasket.OrderByDescending(i => i.NameProduct).ToList();
                    break;
                case 2:
                    listBasket = listBasket.OrderBy(i => i.Price).ToList();
                    break;
                case 3:
                    listBasket = listBasket.OrderByDescending(i => i.Price).ToList();
                    break;
                default:
                    listBasket = listBasket.OrderBy(i => i.IdProduct).ToList();
                    break;
            }

            var selectFiltr = cmbFiltrationCategory.SelectedIndex;
            if (selectFiltr != 0)
            {
                listBasket = listBasket.Where(i => i.IdCategory == selectFiltr).ToList();
            }
            listBasket = listBasket.Skip(10 * numPage).Take(10).ToList();
            LvBasket.ItemsSource = listBasket;
        }


        private void LvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            Filtr();


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
            Filtr();
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (listBasket.Count > 0)
            {
                numPage++;
                tbckPage.Text = (numPage + 1).ToString();
            }
            Filtr();
        }


     

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы хотите оформить заказ?", "Подтверждение", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < listBasket.Count(); i++)
                {
                    Order orderAdd = new Order();
                    orderAdd.IdBasket = listBasket[i].IdBasket;
                    orderAdd.Date = DateTime.Now;
                    orderAdd.NumOrder = ClassUserId.Instance.NumOrder;
                    DB.Order.Add(orderAdd);
                    DB.SaveChanges();
                    
                }
                ClassUserId.Instance.NumOrder++;

                MessageBox.Show("Заказ оформлен", "Заказ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Заказ не оформлен", "Отмена", MessageBoxButton.OK);
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listBasket = listBasket.Where(i => i.NameProduct.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
        }

        private void cmbFiltrationCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }

        private void cmbSortingPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }
    }
}
