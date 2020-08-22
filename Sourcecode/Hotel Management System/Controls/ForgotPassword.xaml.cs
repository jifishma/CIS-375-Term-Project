using Hotel_Management_System.Entities;
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

namespace Hotel_Management_System.Controls
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : UserControl, IRefreshable
    {
        public ForgotPassword()
        {
            InitializeComponent();
            RefreshView();
        }

        public void RefreshView()
        {
            Label_Find_Result.Visibility = Visibility.Hidden;
            TextBox_Username.Text = string.Empty;
            TextBox_Password.Text = string.Empty;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                retrieveAccountPassword(sender, null);
        }

        private void retrieveAccountPassword(object sender, RoutedEventArgs e)
        {
            TextBox_Password.Text = string.Empty;
            User user = ControlFactory.HotelDB.Users.FirstOrDefault(u => u.username.Equals(TextBox_Username.Text));

            if (user != null)
            {
                TextBox_Password.Text = user.password;
                Label_Find_Result.Content = "User information retrieved";
                Label_Find_Result.Foreground = Brushes.DarkGreen;
            }
            else
            {
                Label_Find_Result.Content = "Could not retrieve user information";
                Label_Find_Result.Foreground = Brushes.DarkRed;
            }

            Label_Find_Result.Visibility = Visibility.Visible;
        }
    }
}
