using Microsoft.Win32;
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
using System.Data.Entity.Infrastructure;
using System.IO;

namespace RoomTarKuz.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminEditProduct.xaml
    /// </summary>
    public partial class AdminEditProduct : Window
    {
        public string FileName;

        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        private Image imgImageProduct = new Image();
        private List<Product> listProduct = new List<Product>();
        private string PathProduct;
        private int ID = 0;
        private byte[] OldPhoto = null;

        public AdminEditProduct(int IdED, string NameED, decimal PriceED, string MaterialED,
            string DiscriptionED, int CatED, byte[] PhotoED)
        {
            InitializeComponent();
            ID = IdED;
            txbName.Text = NameED;
            txbPrice.Text = PriceED.ToString();
            txbDescription.Text = DiscriptionED;
            txbMaterial.Text = MaterialED;
            OldPhoto = PhotoED;
            List<Category> category = DB.Category.ToList();
            List<string> cate = new List<string>();
            foreach (var i in category)
            {
                cate.Add(i.NameCategory);
            }
            cate.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = cate;
            cmbFiltrationCategory.SelectedIndex = CatED;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы хотите редактировать материал?", "Подтверждение", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //listProduct = listProduct.Where(i => i.IdCategory == selectFiltr).ToList();
                //var userModel = DB.User.FirstOrDefault
                //(i => i.Login == txbLogin.Text && i.Password == psdPassword.Password && i.IsDeleted != true);
                Product prodEdit = DB.Product.Where(i => i.IdProduct == ID).SingleOrDefault();
                prodEdit.NameProduct = txbName.Text;
                prodEdit.IdCategory = cmbFiltrationCategory.SelectedIndex;
                prodEdit.Price = Convert.ToDecimal(txbPrice.Text);
                prodEdit.Description = txbDescription.Text;
                prodEdit.Material = txbMaterial.Text;
                prodEdit.PhotoProduct = FileName != null ?
                getJPGFromImageControl(imgImageProduct.Source as BitmapImage) : OldPhoto;

                // DB.Product.Add(prodEdit);
                DB.SaveChanges();
                MessageBox.Show("Товар успешно изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == true)
            {
                FileName = openFD.FileName;
                imgImageProduct.Source = new BitmapImage(new Uri(openFD.FileName));
            }
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cmbFiltrationCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}