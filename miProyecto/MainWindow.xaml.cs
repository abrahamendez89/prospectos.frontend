using miProyecto.UCVentanas;
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
using UI.UserControls;

namespace miProyecto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            UCOpcionMenu om = new UCOpcionMenu();
            om.UCText = "Captura Prospectos";
            om.UCUserControl = typeof(UCCapturaProspecto);
            om.UCClick += Om_UCClick;

            this.spOpciones.Children.Add(om);
        }

        private void Om_UCClick(UCOpcionMenu uc)
        {
            UserControl ucontrol = (UserControl)Activator.CreateInstance(uc.UCUserControl);
            scViewer.Content = ucontrol;
            spAcciones.Children.Clear();
            //obteniendo actions del control

            UCButton btnSalir = new UCButton();
            btnSalir.UCText = "Salir";
            btnSalir.UCIcon = Meziantou.WpfFontAwesome.FontAwesomeSolidIcon.PowerOff;
            btnSalir.UCClick += BtnSalir_UCClick;
            
            foreach (MethodInfo mi in ucontrol.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                if (mi.Name.StartsWith("Action_"))
                {
                    String nombreMetodo = mi.Name.Replace("Action_", "");
                    String icon = nombreMetodo.Split('_')[0];
                    String nombreAccion = nombreMetodo.Replace(icon + "_", "").Replace("_", " ");

                    UCButton uCB = new UCButton();
                    uCB.UCText = nombreAccion;
                    uCB.UCAction = mi.Name;
                    try
                    {
                        uCB.UCIcon = (Meziantou.WpfFontAwesome.FontAwesomeSolidIcon)Enum.Parse(typeof(Meziantou.WpfFontAwesome.FontAwesomeSolidIcon), icon);
                    }
                    catch
                    {
                        uCB.UCIcon = Meziantou.WpfFontAwesome.FontAwesomeSolidIcon.Link;
                    }
                    uCB.UCClick += UCB_UCClick;

                    spAcciones.Children.Add(uCB);

                }
            }

            spAcciones.Children.Add(btnSalir);
        }

        private void BtnSalir_UCClick(UCButton uc)
        {
            if (MessageBox.Show("¿Está seguro que desea salir? Se perderán los cambios no guardados.", "Pregunta", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.spAcciones.Children.Clear();
                this.scViewer.Content = null;
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
