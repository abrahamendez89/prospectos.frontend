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

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for UCTextbox.xaml
    /// </summary>
    public partial class UCTextbox : UserControl
    {
        public UCTextbox()
        {
            InitializeComponent();
        }
        private Boolean isValid = true;
        public Boolean UCIsValid { get { return isValid; } set { isValid = value; if (!isValid) { rectangle.Stroke = Brushes.Red; label.Visibility = Visibility.Visible; } else { rectangle.Stroke = Brushes.Black; label.Visibility = Visibility.Collapsed; } } }
        
        public String UCText { get { return txt.Text; } set { txt.Text = value; } }
    }
}
