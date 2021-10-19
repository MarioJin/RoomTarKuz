using Microsoft.Win32;
using RoomTarKuz.Helper;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminAddProduct.xaml
    /// </summary>
    public partial class AdminAddProduct : Window
    {
        public string FileName;

        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        Image imgImageProduct = new Image();
        List<Product> listProduct = new List<Product>();
        string PathProduct;

        public AdminAddProduct()
        {
            InitializeComponent();
            var category = DB.Category.ToList();
            List<string> cate = new List<string>();
            foreach (var i in category)
            {
                cate.Add(i.NameCategory);
            }
            cate.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = cate;
            cmbFiltrationCategory.SelectedIndex = 0;
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFiltrationCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       
           
        }
        private void txbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == true)
            {
                FileName = openFD.FileName;
                imgImageProduct.Source = new BitmapImage(new Uri(openFD.FileName));
            }
        }

        private void txbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
           Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы хотите добвить товар?", "Подтверждение", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Product prodAdd = new Product();
                {
                    prodAdd.NameProduct = txbName.Text;
                    prodAdd.IdCategory = cmbFiltrationCategory.SelectedIndex;
                    prodAdd.Price = Convert.ToDecimal(txbPrice.Text);
                    prodAdd.Description = txbDescription.Text;
                    prodAdd.Material = txbMaterial.Text;
                    prodAdd.PhotoProduct = FileName != null ?
                    getJPGFromImageControl(imgImageProduct.Source as BitmapImage) : null;
                };

                DB.Product.Add(prodAdd);
                DB.SaveChanges();
                MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Товар не добавлен", "Отмена",MessageBoxButton.OK);
            }
        }

        private byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }
    }
}
