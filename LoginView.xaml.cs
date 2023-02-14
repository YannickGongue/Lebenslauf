using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaktionslogik für PageLogin.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private NewPassordViewModel newPassord;
        private RegisterViewModel userRegister;
        private RegisterView register;
        private UserResetView ResetView;

        public LoginView()
        {
            this.newPassord = new NewPassordViewModel();
            this.userRegister = new RegisterViewModel();
            InitializeComponent();
        }

       
        private void PasswordResetHyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.ResetView = new UserResetView();

            this.ResetView.Show();
        }

        private void UserRegisterHyperlink_Click(object sender, RoutedEventArgs e)
        {
            this.register = new RegisterView();
            if (!this.userRegister.SetActivedWindow)
            {
                register.Show();
                this.userRegister.SetActivedWindow = true;
            }
        }

        private void ucRoundButton_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
