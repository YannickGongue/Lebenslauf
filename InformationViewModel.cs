using EngineeringToolsCV_1.Command;
using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace EngineeringToolsCV_1.ViewModels
{
    public class InformationViewModel : ViewModelBase
    {
        private ObservableCollection<string> cityList;

        private NavigationBarViewModel navigationBar;

        public ICommand NavigateCancelCommand { get; set; }

        public ObservableCollection<string> CityList
        {
            get
            {
                return this.cityList;
            }

            set
            {
                this.cityList = value;
                OnPropertyChanged(nameof(CityList));
            }
        }

        public InformationViewModel(NavigationStore navigationStore)
        {
            CityList = new ObservableCollection<string>
            {
                "Salzgitter", "Braunschweig", "Hannover", "Hildesheim", "Salder"
            };

            this.executeCancelCommand(navigationStore);           
        }

        public void executeCancelCommand(NavigationStore navigationStore)
        {
            navigationBar = new NavigationBarViewModel("Home -> Dashboard");

            NavigateCancelCommand = new NavigateCommand<DashboardViewModel>(
               new LayoutNavigationService<DashboardViewModel>(navigationStore,
               () => new DashboardViewModel(navigationStore), navigationBar));
        }
    }
}
