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

namespace RoomTarKuz.Shopper
{
    /// <summary>
    /// Логика взаимодействия для EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        public string FileName;

        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        Image imgImageUser = new Image();
        private byte[] OldPhoto = null;


        public EditProfile(string strFirstNameED, string strLastNameED, string strPatronymicED, string phoneED, string emailED, byte[] bPhotoED)
        {
            InitializeComponent();

           

            txbFirstName.Text = strFirstNameED;
            txbLastName.Text = strLastNameED;
            txbPatronymic.Text = strPatronymicED;
            txbPhone.Text = phoneED;
            txbEmail.Text = emailED;
            OldPhoto = bPhotoED;
            
        }

        private void txbFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbPatronymic_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                imgImageUser.Source = new BitmapImage(new Uri(openFD.FileName));
            }
        }

        private void txbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var v = DB.User.Find(ClassUserId.Instance.idUserInt);
            var log = v.Login;
            var pass = v.Password;
            var role = v.IdRole;
          
           // DB.User.Remove(v);
            var result = MessageBox.Show("Вы хотите редактировать профиль?", "Подтверждение", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                User userEdit = new User
                {
                    FirstName = txbFirstName.Text,
                    LastName = txbLastName.Text,
                    Patronymic = txbPatronymic.Text,
                    Phone = txbPhone.Text,
                    Email = txbEmail.Text,
                    Password = pass,
                    Login = log,
                    IdRole = role,
                    
                    PhotoUser = FileName != null ?
                   getJPGFromImageControl(imgImageUser.Source as BitmapImage) : OldPhoto
                };

                DB.User.Add(userEdit);
               
                DB.SaveChanges();

                ClassUserId.Instance.idUserInt = userEdit.IdUser;
                userEdit = null;
                MessageBox.Show("Профиль успешно изменен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
