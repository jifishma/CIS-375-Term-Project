using Hotel_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for Reserve.xaml
    /// </summary>
    public partial class Reserve : UserControl, IRefreshable
    {
        private Package package = null;

        public Reserve(Package amenity)
        {
            this.package = amenity;

            InitializeComponent();
            ControlFactory.frameControl.SetTitle("Create A Reservation");
            RefreshView();
        }

        public void RefreshView()
        {
            Label_Package.Content = package.name + " | " + ((Enums.Package)package.type).ToString();
            Label_Occupancy.Content = package.capacity;
            Label_Availability.Content = ((Enums.Availability)package.availability).ToString();
            Label_Cost.Content = package.price;
            Label_RewardsCost.Content = package.rewards;
            Label_RewardsAvailable.Content = ControlFactory.frameControl.authenticatedUser.availableRewards;
            DatePicker_Date.SelectedDate = DateTime.Today;
        }

        private void createReservation(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = ControlFactory.frameControl.authenticatedUser;

                ControlFactory.HotelDB.Reservations.Add(new Reservation
                {
                    createdByUserId = user.userID,
                    userID = user.userID,
                    packageID = package.packageID,
                    reservationsFrom = DatePicker_Date.SelectedDate.Value,
                    reservationsTo = DatePicker_Date.SelectedDate.Value
                });

                ControlFactory.HotelDB.SaveChanges();

                Label_RewardsAvailable.Content = user.availableRewards;
            }
            catch
            {

            }
        }

        private void CheckBox_UseRewards_Checked(object sender, RoutedEventArgs e)
        {
            var user = ControlFactory.frameControl.authenticatedUser;

            if (user.availableRewards < package.rewards)
            {
                Button_Reserve.IsEnabled = false;
                Border_Rewards.BorderBrush = Brushes.Red;
            }
        }

        private void CheckBox_UseRewards_Unchecked(object sender, RoutedEventArgs e)
        {
            Button_Reserve.IsEnabled = true;
            Border_Rewards.BorderBrush = Brushes.White;
        }
    }
}
