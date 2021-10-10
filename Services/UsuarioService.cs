using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilities;

namespace Services
{
    public class UsuarioService
    {
        Httphelper hh;
        public UsuarioService()
        {
            hh = new Httphelper();
            hh.BaseURI = new Uri(Constants.BACKEND_URL);
        }
        public async Task<Token> PostLogin(Usuario u)
        {
            Token t;
            try
            {
                t = await hh.Post<Token, Usuario>("login", u);

            }
            catch (CustomHttpException ce)
            {
                throw ce;
            }
            return t;
        }
    }
}
