using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EngineeringToolsCV_1.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private bool setActivedWindow;
        private string username;
        private string passwort;
        private string confirmPassword;
        private string emailAdresse;

        public bool SetActivedWindow
        {
            get { return this.setActivedWindow; }
            set
            {
                if (this.setActivedWindow != value)
                {
                    this.setActivedWindow = value;
                    this.OnPropertyChanged(nameof(SetActivedWindow));
                }
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                this.OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return this.passwort;
            }

            set
            {
                this.passwort = value;
                this.OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return this.confirmPassword;
            }

            set
            {
                this.confirmPassword = value;
                this.OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string EmailAdress
        {
            get
            {
                return this.emailAdresse;
            }

            set
            {
                this.emailAdresse = value;
                this.OnPropertyChanged(nameof(EmailAdress));
            }
        }
    }
}
