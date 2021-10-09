using Domain;
using Meziantou.WpfFontAwesome;
using Services;
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
using UI;
using Utilities;

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCListadoProspectos.xaml
    /// </summary>
    public partial class UCListadoProspectos : UserControl
    {
        ProspectoService ps = new ProspectoService();
        List<Prospecto> p;
        public UCListadoProspectos()
        {
            InitializeComponent();
            CargaProspectos();
            if (Storage.Rol.Equals("Validador"))
                gridProspectos.MouseDoubleClick += GridProspectos_MouseDoubleClick;
        }

        private void GridProspectos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Prospecto p = (Prospecto)gridProspectos.SelectedItem;

            /*
            Window w = new Window();
            UCContenedor uc = new UCContenedor();
            UCCapturaProspecto ucp = new UCCapturaProspecto();
            uc.Tag = w;
            ucp.Tag = w;
            uc.agregarUC(ucp);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            w.Content = new Grid();
            ((Grid)w.Content).Children.Add(uc);
            ucp.CargaProspectoYDocumentosPorID(p.prospecto_id);
            w.ShowDialog();
            */
            UCCapturaProspecto ucp = new UCCapturaProspecto();
            ucp.CargaProspectoYDocumentosPorID(p.prospecto_id);
            UCHelper.UCShowContainer(ucp);

            CargaProspectos();
        }

        [UCActionHelper(UCRol = "Prospecto", UCIcon = FontAwesomeSolidIcon.Check, UCNombreAccion = "Actualizar")]
        public async void CargaProspectos()
        {
            try
            {
                p = await ps.GetProspectos();
                gridProspectos.ItemsSource = p;

                foreach (DataGridColumn dgc in gridProspectos.Columns)
                {
                    dgc.Header = dgc.Header.ToString().Replace("prospecto", "").Replace("_", " ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
