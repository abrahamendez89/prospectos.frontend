using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace miProyecto.UCVentanas
{
    public class UCHelper
    {
        public static void UCShowContainer(UserControl ucc)
        {
            Window w = new Window();
            UCContenedor uc = new UCContenedor();
            //UCCapturaProspecto ucp = new UCCapturaProspecto();
            uc.Tag = w;
            ucc.Tag = w;
            uc.agregarUC(ucc);
            w.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            w.Content = new Grid();
            ((Grid)w.Content).Children.Add(uc);
            //ucp.CargaProspectoYDocumentosPorID(p.prospecto_id);
            w.ShowDialog();
        }
        public static void UCCloseContainer(UserControl ucc)
        {
            if (ucc.Tag != null)
            {
                Window window = (Window)ucc.Tag;
                window.Tag = true;
                window.Close();
            }
        }
    }
}
