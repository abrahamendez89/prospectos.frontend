using Meziantou.WpfFontAwesome;
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
    /// Interaction logic for NavBarButton.xaml
    /// </summary>
    public partial class NavBarButton : UserControl
    {
        public delegate void _onClick(NavBarButton uc);
        public event _onClick onClick;
        public double IconSize { get { return icon.FontSize; } set { icon.FontSize = value; } }
        public FontAwesomeSolidIcon? Icon { get { return icon.SolidIcon; } set { icon.SolidIcon = value; } }

        public Brush IconColor { get { return this.iconColor; } set { icon.Foreground = value; if(this.iconColor == null) this.iconColor = value; } }
        public Brush IconOverColor { get { return this.overIconColor; } set { this.overIconColor = value; } }
        private Brush overIconColor;
        private Brush iconColor;
        public NavBarButton()
        {
            InitializeComponent();
            this.grid.MouseEnter += NavBarButton_MouseEnter;
            this.grid.MouseLeave += NavBarButton_MouseLeave;

        }

        private void NavBarButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.icon.Foreground = iconColor;
            this.grid.Cursor = Cursors.Hand;
        }

        private void NavBarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            this.icon.Foreground = overIconColor;
            this.grid.Cursor = Cursors.Arrow;
        }
    }
}
