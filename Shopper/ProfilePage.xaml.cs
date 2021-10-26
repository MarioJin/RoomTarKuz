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
            listUser = DB.User.Where(i => i.IdUser == ClassUserId.Instance.idUserInt).ToList();
            LvProfile.ItemsSource = listUser;

        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            var user = DB.User.Find(ClassUserId.Instance.idUserInt);

            string strFirstName = user.FirstName;
            string strLastName = user.LastName;
            string strPatronymic = user.Patronymic;
            string Phone = user.Phone;
            string Email = user.Email;

            byte[] bPhoto = user.PhotoUser;

            //string strFirstName = listUser[LvProfile.SelectedIndex].FirstName;
            //string strLastName = listUser[LvProfile.SelectedIndex].LastName;
            //string strPatronymic = listUser[LvProfile.SelectedIndex].Patronymic;
            //string Phone = listUser[LvProfile.SelectedIndex].Phone;
            //string Email = listUser[LvProfile.SelectedIndex].Email;

            //byte[] bPhoto = listUser[LvProfile.SelectedIndex].PhotoUser;

            EditProfile editProfile = new EditProfile(strFirstName, strLastName,
                strPatronymic, Phone, Email, bPhoto);
            editProfile.Show();
            
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
