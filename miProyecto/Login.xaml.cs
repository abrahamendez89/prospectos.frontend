using Domain;
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
        Httphelper httpHelper = new Httphelper();
        public Login()
        {
            InitializeComponent();
            httpHelper.BaseURI = new Uri(@"http://localhost:3000/");
            btnEntrar.Click += BtnEntrar_Click;
        }

        private async void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario userBody = new Usuario();
            userBody.usuario_usuario = txtUser.Text;
            userBody.usuario_contrasena = txtPassword.Password;
            try
            {
                Token token = await httpHelper.Post<Token, Usuario>("login", userBody);
                Storage.Token = token.token;

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();

            }catch(CustomHttpException ce)
            {
                
                MessageBox.Show("Usuario y/o Contraseña incorrectos", "Acceso "+ce.HttpCode, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
    }
}
