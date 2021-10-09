using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using UI;
using UI.UserControls;
using Utilities;

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCContenedor.xaml
    /// </summary>
    public partial class UCContenedor : UserControl
    {
        public UCContenedor()
        {
            InitializeComponent();
        }

        public void agregarUC(UserControl uc)
        {
            scViewer.Content = uc;
            spAcciones.Children.Clear();
            //obteniendo actions del control
            if (this.Tag != null)
            {
                Window window = (Window)this.Tag;
                window.Closing += Window_Closing;
            }

            UCButton btnSalir = new UCButton();
            btnSalir.UCText = "Salir";
            btnSalir.UCIcon = Meziantou.WpfFontAwesome.FontAwesomeSolidIcon.PowerOff;
            btnSalir.UCClick += BtnSalir_UCClick;

            foreach (MethodInfo mi in uc.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                foreach (Attribute at in mi.GetCustomAttributes())
                {
                    if (at.GetType() == typeof(UCActionHelper))
                    {
                        UCActionHelper ah = (UCActionHelper)at;

                        if (!ah.UCRol.Equals(Storage.Rol))
                            continue;

                        UCButton uCB = new UCButton();
                        uCB.UCText = ah.UCNombreAccion;
                        uCB.UCIcon = ah.UCIcon;
                        uCB.UCAction = mi.Name;
                        uCB.UCClick += UCB_UCClick;

                        spAcciones.Children.Add(uCB);
                    }
                }
            }

            spAcciones.Children.Add(btnSalir);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Tag != null && ((Window)this.Tag).Tag != null) return;
            e.Cancel = true;
        }

        private void BtnSalir_UCClick(UCButton uc)
        {
            if (MessageBox.Show("¿Está seguro que desea salir? Se perderán los cambios no guardados.", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.spAcciones.Children.Clear();
                this.scViewer.Content = null;
                if (this.Tag != null)
                {
                    Window window = (Window)this.Tag;
                    window.Tag = true;
                    window.Close();
                }
            }

        }

        private void UCB_UCClick(UCButton uc)
        {
            try
            {
                MethodInfo voidMethodInfo = scViewer.Content.GetType().GetMethod(uc.UCAction);
                voidMethodInfo.Invoke(scViewer.Content, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
