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
using Utilities;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for UCOpcionMenu.xaml
    /// </summary>
    public partial class UCOpcionMenu : UserControl
    {

        public delegate void _UCClick(UCOpcionMenu uc);
        public event _UCClick UCClick;

        public String UCText { get { return lblOpcion.Content.ToString(); } set { lblOpcion.Content = value; } }
        public Type UCUserControl { get; set; }

        public UCOpcionMenu()
        {
            InitializeComponent();
            this.MouseEnter += UCOpcionMenu_MouseEnter;
            this.MouseLeave += UCOpcionMenu_MouseLeave;
            this.MouseUp += UCOpcionMenu_MouseUp;
        }

        private void UCOpcionMenu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(UCClick != null)
            {
                UCClick(this);
            }
        }

        private void UCOpcionMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            rectangle.Fill = UCUtils.ConvertHEXToBrush("#FFE0E0E0");
            this.Cursor = Cursors.Arrow;
        }

        private void UCOpcionMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            rectangle.Fill = UCUtils.ConvertHEXToBrush("#FF86CFEA");
            this.Cursor = Cursors.Hand;
        }
    }
}
