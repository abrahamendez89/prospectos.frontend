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
        public delegate void _UCSelectedFile(UCCapturaProspectoDocumento uc);
        public event _UCSelectedFile UCSelectedFile;

        public delegate void _UCDownloadFileClick(UCCapturaProspectoDocumento uc);
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
            if (UCBase64File != null && UCFileName != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = UCFileName;

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileHelper.Base64StringToFile(UCBase64File, saveFileDialog.FileName);

                    if (UCSelectedFile != null)
                    {
                        UCSelectedFile(this);
                    }
                }
            }
            if (UCBase64File == null && UCFileName != null)
            {

                if (UCDownloadFileClick == null)
                {
                    throw new Exception("Es necesario asignar el evento UCDownloadFileClick para descargar el archivo del servidor.");
                }
                UCDownloadFileClick(this);
            }
        }
        public void UCToFile()
        {
            BtnDescargar_UCClick(null);
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
                    UCSelectedFile(this);
                }
            }

        }
    }
}
