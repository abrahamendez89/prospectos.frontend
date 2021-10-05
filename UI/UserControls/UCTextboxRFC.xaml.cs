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
    public partial class UCTextboxRFC : UserControl
    {
        public UCTextboxRFC()
        {
            InitializeComponent();
            txt.LostFocus += Txt_LostFocus;
            txt.KeyUp += Txt_KeyUp;
        }

        private void Txt_KeyUp(object sender, KeyEventArgs e)
        {
            int index = Int32.Parse(e.OriginalSource.GetType().GetProperty("CaretIndex").GetValue(e.OriginalSource).ToString());
            txt.Text = txt.Text.ToUpper();
            e.OriginalSource.GetType().GetProperty("CaretIndex").SetValue(e.OriginalSource, index);
        }

        private void Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))((-)?([A-Z\d]{3}))?$");
            Match match = regex.Match(txt.Text);
            if (!match.Success)
            {
                this.UCIsValid = false;
                this.ToolTip = "RFC Incorrecto";
            }
            else
            {
                this.UCIsValid = true;
                this.ToolTip = null;
            }
        }

        private Boolean isValid = true;
        public Boolean UCIsValid { get { return isValid; } set { isValid = value; if (!isValid) { rectangle.Stroke = Brushes.Red; label.Visibility = Visibility.Visible; } else { rectangle.Stroke = Brushes.Black; label.Visibility = Visibility.Collapsed; } } }
        
        public String UCText { get { return txt.Text; } set { txt.Text = value; } }
    }
}
