using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilities;
using Utilities;

namespace Services
{
    public class DocumentoService
    {
        Httphelper hh;
        public DocumentoService()
        {
            hh = new Httphelper();
            hh.BaseURI = new Uri(Constants.BACKEND_URL);
        }
        public async Task<Documento> GetDocumentoByID(Documento doc)
        {
            try
            {
                doc = await hh.Get<Documento>("documento/"+doc.documento_id, Storage.Token);

            }
            catch (CustomHttpException ce)
            {
                throw ce;
            }
            return doc;
        }
        public async Task<List<Documento>> GetDocumentosByProspectoID(int id)
        {
            List<Documento> p = null;
            try
            {
                p = await hh.Get<List<Documento>>("documentop/" + id, Storage.Token);

            }
            catch (CustomHttpException ce)
            {
                throw ce;
            }
            return p;
        }
    }
}
