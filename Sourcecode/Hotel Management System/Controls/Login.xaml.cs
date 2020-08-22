using Hotel_Management_System.Controls;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
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

namespace Hotel_Management_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl, IRefreshable
    {
        public Login()
        {
            InitializeComponent();
        }

        public void RefreshView()
        {
            ControlFactory.frameControl.authenticatedUser = null;

            TextBox_Username.Text = "";
            TextBox_Password.Text = "";

            Label_Login_Error.Visibility = Visibility.Hidden;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                accountLogin(sender, null);
        }

        private void Button_Forgot_User_Click(object sender, RoutedEventArgs e)
        {
            ControlFactory.mainControl.UpdateView(this, ControlFactory.frameControl);
            ControlFactory.subControl.Content = new ForgotPassword();
        }

        private void Button_Create_User_Click(object sender, RoutedEventArgs e)
        {
            ControlFactory.mainControl.UpdateView(this, ControlFactory.frameControl);
            ControlFactory.subControl.Content = new CreateUser();
        }

        private void accountLogin(object sender, RoutedEventArgs e)
        {
            var username = TextBox_Username.Text;
            var password = TextBox_Password.Text;

            var user = ControlFactory.HotelDB.Users
                .Where(u => u.username.Equals(username) && u.password.Equals(password))
                .FirstOrDefault();

            if (user != null)
            {
                user.numLogins++;
                try
                {
                    ControlFactory.HotelDB.Users.AddOrUpdate(user);
                    ControlFactory.HotelDB.SaveChanges();
                }
                catch
                {

                }

                ControlFactory.frameControl.authenticatedUser = user;
                ControlFactory.subControl.Content = new HotelListings();
                ControlFactory.mainControl.UpdateView(this, ControlFactory.frameControl);
            }
            else
            {
                Label_Login_Error.Visibility = Visibility.Visible;
            }
        }
    }
}