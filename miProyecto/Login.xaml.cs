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
using System.Windows.Shapes;
using utilities;
using Utilities;

namespace miProyecto
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UsuarioService us = new UsuarioService();
        public Login()
        {
            InitializeComponent();
            btnEntrar.UCClick += BtnEntrar_UCClick;
        }

        private async void BtnEntrar_UCClick(UI.UserControls.UCButton uc)
        {
            Usuario userBody = new Usuario();
            userBody.usuario_usuario = txtUser.UCText;
            userBody.usuario_contrasena = txtPassword.UCPasswordText;
            
            try
            {
                userBody.DCValidate();
                Token token = await us.PostLogin(userBody);
                Storage.Token = token.token;
                Storage.Rol = token.rol;

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();

            }
            catch (Exception ce)
            {

                MessageBox.Show(ce.Message, "Acceso ", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
