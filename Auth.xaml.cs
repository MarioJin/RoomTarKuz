using RoomTarKuz.Admin;
using RoomTarKuz.Helper;
using RoomTarKuz.Manager;
using RoomTarKuz.Shopper;
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

namespace RoomTarKuz
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public static RoomKuzTarEntities DB = new RoomKuzTarEntities();
        Order order = new Order();
        public Auth()
        {
            ClassUserId.Instance.NumOrder = MaxOrderNum();

           
            InitializeComponent();
            
        }
        public int MaxOrderNum()
        {
            List<Order> listOrder = new List<Order>();
            listOrder = DB.Order.ToList();
            var s = listOrder.ToArray();
            int maxValue = s.AsEnumerable().Select(row => Convert.ToInt32(row.NumOrder)).Max();
            return maxValue;
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var userModel = DB.User.FirstOrDefault
                (i => i.Login == txbLogin.Text && i.Password == psdPassword.Password);
            if (psdPassword.Password == psdPasswordRepeat.Password)
            {
                ClassUserId.Instance.idUserInt = userModel.IdUser;
                if (userModel == null)
                {
                    MessageBox.Show("Пользователь не найден, повторите попытку", "Пользователь не найден", MessageBoxButton.OK);
                }
                else if (userModel.IdRole == 1)
                {
                    AdminMain aM = new AdminMain();
                    aM.Show();
                    Application.Current.MainWindow.Close();
                }
                else if(userModel.IdRole == 3)
                {
                    ShopperMain sM = new ShopperMain();
                    sM.Show();
                    Application.Current.MainWindow.Close();
                }
                else if(userModel.IdRole == 2)
                {
                    ManagerMain mM = new ManagerMain();
                    mM.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Пароль не совпадает, повторите попытку", "Ошибка ввода пароля", MessageBoxButton.OK);
                }
            }
        }
    }
}
