using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private NavigationBarViewModel navigationBar;

        private string displayedImagePath = @"C:\Users\vamic\source\repos\EngineeringToolsCV_1\EngineeringToolsCV_1\Image\job-portfolio.png"; 
        public ICommand NavigateLoginCommand { get; }
        public string DisplayedImagePath
        {
            get { return this.displayedImagePath; }
            set 
            { 
                this.displayedImagePath = value;
                OnPropertyChanged(nameof(DisplayedImagePath));
            }
        }

        public HomeViewModel(NavigationStore navigationStore)
        {
            navigationBar = new NavigationBarViewModel("Home");
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(
                new LayoutNavigationService<LoginViewModel>(navigationStore,
                () => new LoginViewModel(navigationStore), navigationBar));
        }
    }
}
