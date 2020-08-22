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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // JF: animate as a last step? :) 

            //var sb = new Storyboard();
            //Storyboard.SetTarget(sb, label_Welcome);

            //var textSizeUp = new DoubleAnimation
            //{
            //    BeginTime = TimeSpan.FromSeconds(0.5),
            //    Duration = new Duration(TimeSpan.FromSeconds(0.1)),
            //    From = 34,
            //    To = 36
            //};
            //Storyboard.SetTargetProperty(textSizeUp, new PropertyPath(FontSizeProperty));
            //sb.Children.Add(textSizeUp);

            //var centerLabel = new ThicknessAnimation
            //{
            //    BeginTime = TimeSpan.FromSeconds(0.5),
            //    Duration = new Duration(TimeSpan.FromSeconds(1)),
            //    From = new Thickness(0, window.Height / 2 - label_Welcome.Height, 0, 0),
            //    To = new Thickness(0, window.Height / 2 - label_Welcome.Height, 0, 0)
            //};
            //Storyboard.SetTargetProperty(centerLabel, new PropertyPath(MarginProperty));
            //sb.Children.Add(centerLabel);

            //var shiftLabelUp = new ThicknessAnimation
            //{
            //    BeginTime = TimeSpan.FromSeconds(1.5),
            //    Duration = new Duration(TimeSpan.FromSeconds(1)),
            //    From = new Thickness(0, window.Height / 2 - label_Welcome.Height, 0, 0),
            //    To = new Thickness(),
            //    EasingFunction = new CubicEase
            //    {
            //        EasingMode = EasingMode.EaseInOut
            //    }
            //};
            //Storyboard.SetTargetProperty(shiftLabelUp, new PropertyPath(MarginProperty));
            //sb.Children.Add(shiftLabelUp);

            //sb.Begin();
        }

        private void MainControl_Loaded(object sender, RoutedEventArgs e)
        {
            ControlFactory.mainControl = Control_Main;
            Control_Main.Content = ControlFactory.loginControl;
        }
    }
}
