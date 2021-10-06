using Microsoft.Win32;
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

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCCapturaProspectoDocumento.xaml
    /// </summary>
    public partial class UCCapturaProspectoDocumento : UserControl
    {
        public delegate void _UCSelectedFile(String filename, String base64File);
        public event _UCSelectedFile UCSelectedFile;

        public delegate void _UCDownloadFileClick(String filename, String base64File);
        public event _UCDownloadFileClick UCDownloadFileClick;


        public String UCFileName { get { return lblNombreDocumento.Content.ToString(); } set { lblNombreDocumento.Content = value; } }
        public String UCBase64File { get; set; }

        public UCCapturaProspectoDocumento()
        {
            InitializeComponent();
            btnCargar.UCClick += BtnCargar_UCClick;
            btnDescargar.UCClick += BtnDescargar_UCClick;
        }

        private void BtnDescargar_UCClick(UI.UserControls.UCButton uc)
        {
            if (UCDownloadFileClick == null)
            {
                throw new Exception("Es necesario asignar el evento UCDownloadFileClick para descargar el archivo del servidor.");
            }
            if (UCBase64File == null)
            {
                UCDownloadFileClick(UCFileName, UCBase64File);
                if (UCFileName == null || UCBase64File == null)
                {
                    throw new Exception("Es necesario asignar las propiedades UCFileName y UCBase64File con los datos de descarga del servidor..");
                }
            }
            else
            {
                UCDownloadFileClick(UCFileName, UCBase64File);
            }

        }

        private void BtnCargar_UCClick(UI.UserControls.UCButton uc)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                String base64File = FileHelper.FileToBase64String(openFileDialog.FileName);
                String fileName = FileHelper.GetFileNameFromPath(openFileDialog.FileName);
                UCBase64File = base64File;
                UCFileName = fileName;
                if (UCSelectedFile != null)
                {
                    UCSelectedFile(fileName, base64File);
                }
            }

        }
    }
}
