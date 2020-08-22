using Hotel_Management_System.Controls;
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
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class ParentControl : UserControl
    {
        public Stack<IRefreshable> previousViews = new Stack<IRefreshable>();

        public ParentControl()
        {
            InitializeComponent();
        }

        public void UpdateView(IRefreshable origin, IRefreshable target)
        {
            previousViews.Push(origin);
            target.RefreshView();
            Content = target;
        }

        public void RollbackView()
        {
            if (previousViews.Any())
            {
                var previous = previousViews.Pop();
                previous.RefreshView();
                Content = previous;
            }
        }
    }
}
