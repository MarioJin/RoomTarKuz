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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        List<User> listUser = new List<User>();
        public ProfilePage()
        {
            InitializeComponent();
            LvProfile.ItemsSource = DB.User.Where(i => i.IdUser == ClassUserId.Instance.idUserInt).ToList();
            listUser = DB.User.Where(i => i.IdUser == ClassUserId.Instance.idUserInt).ToList();
            LvProfile.ItemsSource = listUser;
            
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            string strFirstName = listUser[LvProfile.SelectedIndex].FirstName;
            string strLastName = listUser[LvProfile.SelectedIndex].LastName;
            string strPatronymic = listUser[LvProfile.SelectedIndex].Patronymic;
            string Phone = listUser[LvProfile.SelectedIndex].Phone;
            string Email = listUser[LvProfile.SelectedIndex].Email;

            byte[] bPhoto = listUser[LvProfile.SelectedIndex].PhotoUser;

            EditProfilePage editProfile = new EditProfilePage(strFirstName, strLastName,
                strPatronymic, Phone, Email, bPhoto);

            frmMainShopper.Navigate(editProfile);
            //int ID = listProduct[LvProduct.SelectedIndex].IdProduct;
            //string strName = listProduct[LvProduct.SelectedIndex].NameProduct.ToString();
            //string strPrice = listProduct[LvProduct.SelectedIndex].Price.ToString();
            //string strMaterial = listProduct[LvProduct.SelectedIndex].Material.ToString();
            //string strDiscription = listProduct[LvProduct.SelectedIndex].Description.ToString();
            //int IDCat = listProduct[LvProduct.SelectedIndex].IdCategory;
            //byte[] bPhoto = listProduct[LvProduct.SelectedIndex].PhotoProduct;

            //AdminEditProduct editProduct = new AdminEditProduct(ID, strName,
            //    Convert.ToDecimal(strPrice), strMaterial,
            //    strDiscription, IDCat, bPhoto);

            //editProduct.Show();
        }

        private void btnBackFrm_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }

        private void LvProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
