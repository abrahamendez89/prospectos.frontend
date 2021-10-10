
﻿using miProyecto.UCVentanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using UI.UserControls;
using Utilities;

namespace miProyecto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Storage.Rol.Equals("Promotor"))
            {
                UCOpcionMenu om = new UCOpcionMenu();
                om.UCText = "Captura Prospectos";
                om.UCUserControl = typeof(UCCapturaProspecto);
                om.UCClick += Om_UCClick;
                this.spOpciones.Children.Add(om);

            }
            if (Storage.Rol.Equals("Validador") || Storage.Rol.Equals("Promotor"))
            {
                UCOpcionMenu om2 = new UCOpcionMenu();
                om2.UCText = "Lista Prospectos";
                om2.UCUserControl = typeof(UCListadoProspectos);
                om2.UCClick += Om_UCClick;
                this.spOpciones.Children.Add(om2);
            }
            

        }

        private void Om_UCClick(UCOpcionMenu uc)
        {
            UserControl ucontrol = (UserControl)Activator.CreateInstance(uc.UCUserControl);
            contenedor.agregarUC(ucontrol);
        }
    }
}
