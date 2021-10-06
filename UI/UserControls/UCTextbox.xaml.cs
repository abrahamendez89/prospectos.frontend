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
            txt.LostFocus += Txt_LostFocus;
        }

        private void Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UCIsANumber)
            {
                Regex regex = new Regex(@"^\d$");
                Match match = regex.Match(txt.Text);
                if (!match.Success)
                {
                    this.UCIsValid = false;
                    this.ToolTip = "Debe ser un Número";
                }
                else
                {
                    this.UCIsValid = true;
                    this.ToolTip = null;
                }
            }
        }

        private Boolean isValid = true;
        public Boolean UCIsValid { get { return isValid; } set { isValid = value; if (!isValid) { rectangle.Stroke = Brushes.Red; label.Visibility = Visibility.Visible; } else { rectangle.Stroke = Brushes.Black; label.Visibility = Visibility.Collapsed; } } }
        public Boolean UCIsANumber { get; set; }
        public String UCText { get { return txt.Text; } set { txt.Text = value; } }
    }
}
