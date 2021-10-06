﻿using Domain;
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
            btnEntrar.UCClick += BtnEntrar_UCClick;
        }

        private async void BtnEntrar_UCClick(UI.UserControls.UCButton uc)
        {
            Usuario userBody = new Usuario();
            userBody.usuario_usuario = txtUser.UCText;
            userBody.usuario_contrasena = txtPassword.UCPasswordText;
            userBody.DCValidate();
            try
            {
                Token token = await httpHelper.Post<Token, Usuario>("login", userBody);
                Storage.Token = token.token;

                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();

            }
            catch (CustomHttpException ce)
            {

                MessageBox.Show("Usuario y/o Contraseña incorrectos", "Acceso " + ce.HttpCode, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
