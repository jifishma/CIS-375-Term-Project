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
    /// Interaction logic for AmenetiesListings.xaml
    /// </summary>
    public partial class PackageListings : UserControl, IRefreshable
    {
        private Hotel hotel = null;

        public PackageListings(Hotel hotel)
        {
            this.hotel = hotel;
            InitializeComponent();
        }

        public void RefreshView()
        {
            ControlFactory.frameControl.SetTitle("Select A Room / Event");
            PopulatePackages();
        }

        private void PopulatePackages()
        {
            WrapPanel_MainControl.Children.Clear();

            foreach (var package in hotel.Packages)
            {
                var border = new Border
                {
                    Width = 200,
                    Height = 200,
                    Margin = new Thickness(20),
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Tag = package
                };

                var stackPanel = new StackPanel
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                stackPanel.Children.Add(new Label
                {
                    Content = package.name,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = ((Enums.Package)package.type).ToString(),
                    FontSize = 14,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = "Located on " + package.location,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = "Capacity: " + package.capacity,
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = string.Format("Price: ${0}, Rewards: {1}p", package.price, package.rewards),
                    Foreground = Brushes.White,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                stackPanel.Children.Add(new Label
                {
                    Content = "Status: " + ((Enums.Availability)package.availability).ToString(),
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
            var package = (sender as Border).Tag as Package;
            ControlFactory.subControl.UpdateView(this, new Reserve(package));
        }
    }
}
