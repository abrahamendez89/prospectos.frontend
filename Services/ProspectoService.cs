using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using utilities;
using Utilities;

namespace Services
{
    public class ProspectoService
    {
        Httphelper hh;
        public ProspectoService()
        {
            hh = new Httphelper();
            hh.BaseURI = new Uri(Constants.BACKEND_URL);
        }
        public async Task<Prospecto> GetProspectoByID(int id)
        {
            Prospecto p = null;
            try
            {
                p = await hh.Get<Prospecto>("prospecto/"+id, Storage.Token);
                
            }catch(CustomHttpException ce)
            {
                throw ce;
            }
            return p;
        }
        public async Task<Prospecto> PostProspecto(ProspectoWrapper pw)
        {
            Prospecto p = null;
            try
            {
                p = await hh.Post<Prospecto, ProspectoWrapper>("prospecto", pw, Storage.Token);

            }
            catch (CustomHttpException ce)
            {
                throw ce;
            }
            return p;
        }
    }
}
