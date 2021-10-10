using Domain;
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
using UI.UserControls;
using UI;
using Meziantou.WpfFontAwesome;

namespace miProyecto.UCVentanas
{
    /// <summary>
    /// Interaction logic for UCCapturaProspecto.xaml
    /// </summary>
    public partial class UCCapturaProspecto : UserControl
    {
        ProspectoService ps = new ProspectoService();
        DocumentoService ds = new DocumentoService();

        Prospecto p = new Prospecto();
        List<Documento> docs = new List<Documento>();
        public UCCapturaProspecto()
        {
            InitializeComponent();
            btnAgregarDocumento.UCClick += BtnAgregarDocumento_UCClick;
        }

        public async void CargaProspectoYDocumentosPorID(int id)
        {
            try
            {
                p = await ps.GetProspectoByID(id);
                docs = await ds.GetDocumentosByProspectoID(id);

                txtNombre.UCText = p.prospecto_nombre;
                txtApPat.UCText = p.prospecto_appaterno;
                txtApMat.UCText = p.prospecto_apmaterno;
                txtRFC.UCText = p.prospecto_RFC;
                txtCalle.UCText = p.prospecto_calle;
                txtNumero.UCText = p.prospecto_numero;
                txtColonia.UCText = p.prospecto_colonia;
                txtCodigoPostal.UCText = p.prospecto_cod_postal;
                txtTelefono.UCText = p.prospecto_tel;

                UIHelper.UCSetReadOnly(this);

                spDocumentos.Children.Clear();
                foreach (Documento d in docs)
                {
                    UCCapturaProspectoDocumento ucDocumento = new UCCapturaProspectoDocumento();
                    ucDocumento.UCFileName = d.documento_nombre_documento;
                    ucDocumento.UCSelectedFile += UcDocumento_UCSelectedFile;
                    ucDocumento.UCDownloadFileClick += UcDocumento_UCDownloadFileClick;
                    ucDocumento.UCIsReadOnly = true;
                    spDocumentos.Children.Add(ucDocumento);
                }
                btnAgregarDocumento.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        [UCActionHelper(UCRol = "Validador", UCIcon = FontAwesomeSolidIcon.Check, UCNombreAccion = "Autorizar Prospecto")]
        public async void autorizarProspecto()
        {
            try
            {
                p.prospecto_estatus = "Autorizado";
                p.prospecto_observaciones = "";
                p = await ps.PostProspecto(p);
                MessageBox.Show("Prospecto guardado exitosamente.", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);

                UCHelper.UCCloseContainer(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        [UCActionHelper(UCRol = "Validador", UCIcon = FontAwesomeSolidIcon.Times, UCNombreAccion = "Rechazar Prospecto")]
        public async void rechazarProspecto()
        {
            try
            {
                UCObservaciones ucp = new UCObservaciones();
                UCHelper.UCShowContainer(ucp);

                p.prospecto_observaciones = ucp.UC_Observaciones;
                if(p.prospecto_observaciones == null || p.prospecto_observaciones.Trim().Equals(""))
                {
                    throw new Exception("Observación obligatoria.");
                }
                p.prospecto_estatus = "Rechazado";
                p = await ps.PostProspecto(p);
                MessageBox.Show("Prospecto guardado exitosamente.", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);

                UCHelper.UCCloseContainer(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        [UCActionHelper(UCRol = "Promotor", UCIcon = FontAwesomeSolidIcon.Save, UCNombreAccion = "Guardar Prospecto")]
        public async void guardarProspecto()
        {
            try
            {

                p.prospecto_nombre = txtNombre.UCText;
                p.prospecto_appaterno = txtApPat.UCText;
                p.prospecto_apmaterno = txtApMat.UCText;
                p.prospecto_RFC = txtRFC.UCText;
                p.prospecto_calle = txtCalle.UCText;
                p.prospecto_numero = txtNumero.UCText;
                p.prospecto_colonia = txtColonia.UCText;
                p.prospecto_cod_postal = txtCodigoPostal.UCText;
                p.prospecto_tel = txtTelefono.UCText;
                p.prospecto_estatus = "Enviado";

                //obteniendo documentos
                ProspectoWrapper pw = new ProspectoWrapper();
                pw.Prospecto = p;
                pw.Documentos = docs;
                pw.Documentos.Clear();
                foreach (UCCapturaProspectoDocumento dc in spDocumentos.Children)
                {
                    Documento doc = new Documento();
                    doc.documento_nombre_documento = dc.UCFileName;
                    doc.documento_data_base64 = dc.UCBase64File;
                    doc.prospecto_id = p.prospecto_id;
                    pw.Documentos.Add(doc);
                }

                try
                {
                    UIHelper.UCValidate(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                p.DCValidate();
                p = await ps.PostProspectoWrapper(pw);



                MessageBox.Show("Prospecto guardado exitosamente.", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);

                UIHelper.UCClear(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnAgregarDocumento_UCClick(UI.UserControls.UCButton uc)
        {
            try
            {
                UCCapturaProspectoDocumento ucDocumento = new UCCapturaProspectoDocumento();
                ucDocumento.UCFileName = "Seleccione un archivo";
                ucDocumento.UCSelectedFile += UcDocumento_UCSelectedFile;
                ucDocumento.UCDownloadFileClick += UcDocumento_UCDownloadFileClick;
                spDocumentos.Children.Add(ucDocumento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void UcDocumento_UCDownloadFileClick(UCCapturaProspectoDocumento uc)
        {
            try
            {
                //entra aqui solo para descargar los archivos del servidor a traves del api documento
                Documento doc = docs.Where(x => x.documento_nombre_documento.Equals(uc.UCFileName)).First();

                doc = await ds.GetDocumentoByID(doc);

                uc.UCBase64File = doc.documento_data_base64;

                uc.UCToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void UcDocumento_UCSelectedFile(UCCapturaProspectoDocumento uc)
        {

        }
    }
}
