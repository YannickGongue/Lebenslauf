using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using EngineeringToolsCV_1.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EngineeringToolsCV_1
{
    /// <summaruserLoginy>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        private SQLServerView ServerView;

        public App()
        {           
            ServerView = new SQLServerView();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {           
           ServerView.Show();               
        }
        
    }
}
