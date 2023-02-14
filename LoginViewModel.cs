using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;

namespace EngineeringToolsCV_1.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string password;
        private string username;
        private IUserRepository userRepository;
        private NavigationBarViewModel navigationBar;

        public ViewModelCommand NavigateLoginCommand { get; }
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel(NavigationStore navigateStore)
        {
            navigationBar = new NavigationBarViewModel("Home -> Dashboard");

            NavigateLoginCommand = new NavigateLoginCommand(this,
                                   new LayoutNavigationService<DashboardViewModel>(navigateStore,
                                   () => new DashboardViewModel(navigateStore), 
                                   navigationBar));
        }    
      
    }
}
