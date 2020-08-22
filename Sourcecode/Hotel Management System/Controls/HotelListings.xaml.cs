using Hotel_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Interaction logic for HotelListings.xaml
    /// </summary>
    public partial class HotelListings : UserControl, IRefreshable
    {
        public HotelListings()
        {
            InitializeComponent();
            RefreshView();
        }

        public void RefreshView()
        {
            ControlFactory.frameControl.SetTitle("Select A Hotel");
            PopulateHotels();
        }

        private void PopulateHotels()
        {
            WrapPanel_MainControl.Children.Clear();

            foreach( var hotel in ControlFactory.HotelDB.Hotels)
            {
                var border = new Border
                {
                    Width = 100,
                    Height = 100,
                    Margin = new Thickness(20),
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Tag = hotel
                };

                var stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                stackPanel.Children.Add(new Label
                {
                    Content = hotel.name,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = "In " + hotel.location,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = hotel.Packages.Count + " rooms / events",
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                border.Child = stackPanel;
                border.MouseLeftButtonUp += Border_MouseLeftButtonUp;
                border.Cursor = Cursors.Hand;

                WrapPanel_MainControl.Children.Add(border);
            };
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var hotel = (sender as Border).Tag as Hotel;
            ControlFactory.subControl.UpdateView(this, new PackageListings(hotel));
        }
    }
}
