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

namespace Hotel_Management_System
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavigationFrame : UserControl, IRefreshable
    {
        public User authenticatedUser { get; set; }

        public NavigationFrame()
        {
            InitializeComponent();
            RefreshView();
        }

        public void RefreshView()
        {
            if (authenticatedUser == null)
            {
                Grid_UserMenu.Visibility = Visibility.Hidden;
                return;
            }

            Grid_UserMenu.Visibility = Visibility.Visible;
            Label_UserStatus.Content = authenticatedUser.isEmployee ? "⚡" : "";
            Label_Username.Content = authenticatedUser.username;
        }

        public void SetTitle(string title)
        {
            Label_Title.Content = title;
        }

        private void Label_Return_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (ControlFactory.subControl.previousViews.Any())
                ControlFactory.subControl.RollbackView();
            else
                ControlFactory.mainControl.RollbackView();
        }
    }
}
