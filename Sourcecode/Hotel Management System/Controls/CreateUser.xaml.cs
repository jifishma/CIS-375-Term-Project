using Hotel_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl, IRefreshable
    {
        private static Regex r = new Regex(@"^[0-9]+\.{0,1}[0-9]{0,2}");

        public CreateUser()
        {
            InitializeComponent();
            RefreshView();
        }

        public void RefreshView()
        {
            ControlFactory.frameControl.SetTitle("Create New User");
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                createAccount(sender, null);
        }

        private void CheckBox_IsAdmin_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBox_IsEmployee.IsChecked.GetValueOrDefault())
                StackPanel_Pay.Visibility = Visibility.Visible;
            else
                StackPanel_Pay.Visibility = Visibility.Collapsed;
        }

        private void TextBox_Pay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var toMatch = TextBox_Pay.Text + e.Text;
            e.Handled = r.Match(toMatch).Value != toMatch;
        }

        private void createAccount(object sender, RoutedEventArgs e)
        {
            User newUser = null;

            try
            {
                if (TextBox_Username.Text == string.Empty)
                    throw new Exception("Empty usernames not allowed");

                newUser = new User
                {
                    isEmployee = CheckBox_IsEmployee.IsChecked.GetValueOrDefault(),
                    username = TextBox_Username.Text,
                    password = TextBox_Password.Text
                };

                if (TextBox_Pay.Text.Trim() != string.Empty)
                    newUser.pay = float.Parse(TextBox_Pay.Text.Trim());

                ControlFactory.HotelDB.Users.Add(newUser);
                ControlFactory.HotelDB.SaveChanges();

                Label_Add_Result.Content = string.Format("New member {0} added successfully", newUser.username);
                Label_Add_Result.Foreground = Brushes.DarkGreen;
            }
            catch
            {
                if (newUser != null)
                    ControlFactory.HotelDB.Users.Local.Remove(newUser);

                Label_Add_Result.Content = "An error occurred while adding the new user";
                Label_Add_Result.Foreground = Brushes.DarkRed;
            }
            Label_Add_Result.Visibility = Visibility.Visible;
        }
    }
}
