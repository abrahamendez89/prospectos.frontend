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

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCCapturaProspecto.xaml
    /// </summary>
    public partial class UCCapturaProspecto : UserControl
    {
        public UCCapturaProspecto()
        {
            InitializeComponent();
            btnAgregarDocumento.UCClick += BtnAgregarDocumento_UCClick;
        }

        private void BtnAgregarDocumento_UCClick(UI.UserControls.UCButton uc)
        {
            UCCapturaProspectoDocumento ucDocumento = new UCCapturaProspectoDocumento();
            ucDocumento.UCFileName = "Seleccione un archivo";
            ucDocumento.UCSelectedFile += UcDocumento_UCSelectedFile;
            ucDocumento.UCDownloadFileClick += UcDocumento_UCDownloadFileClick;
            spDocumentos.Children.Add(ucDocumento);
        }

        private void UcDocumento_UCDownloadFileClick(string filename, string base64File)
        {
            
        }

        private void UcDocumento_UCSelectedFile(string filename, string base64File)
        {
            
        }
    }
}
