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
using UI;

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCObservaciones.xaml
    /// </summary>
    public partial class UCObservaciones : UserControl
    {
        public UCObservaciones()
        {
            InitializeComponent();
        }
        public String UC_Observaciones { get; set; }
        [UCActionHelper(UCRol = "Validador", UCIcon = FontAwesomeSolidIcon.Save, UCNombreAccion = "Guardar")]
        public async void guardaObservacion()
        {
            try
            {
                UIHelper.UCValidate(this);
                this.UC_Observaciones = txtObservaciones.UCText;
                UCHelper.UCCloseContainer(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
