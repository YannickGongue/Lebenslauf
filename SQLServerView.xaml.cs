using EngineeringToolsCV_1.Service;
using EngineeringToolsCV_1.Store;
using EngineeringToolsCV_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EngineeringToolsCV_1.Views
{
    /// <summary>
    /// Interaktionslogik für SQLServerView.xaml
    /// </summary>
    public partial class SQLServerView : Window
    {
        private MainWindow mainWindow;
        private NavigationStore navigationStore;
        private NavigationBarViewModel _NavigationBar;
        private SQLServerViewModel ServerViewModel;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        string ConnectionStringKey;
        Configuration config;

        public SQLServerView()
        {
            InitializeComponent();
            navigationStore = new NavigationStore();
            mainWindow = new MainWindow();
            _NavigationBar = new NavigationBarViewModel("Home");
            ServerViewModel = new SQLServerViewModel();
            this.ServerViewModel.SetEnable = false;
            this.cmbServerTyp.ItemsSource = ServerViewModel.ListServerTyp;
            this.CmbServername.ItemsSource = ServerViewModel.ListServerName;
            this.cmbAuthenticationType.ItemsSource = ServerViewModel.ListAuthentifizierung;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();      
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            con.Close();
            this.AddNewConnectionString();

            MessageBox.Show("Connected to the " + Cmbdatabase.Text + " Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            INavigateService<HomeViewModel> homeNavigationService = new LayoutNavigationService<HomeViewModel>(navigationStore,
                         () => new HomeViewModel(navigationStore), _NavigationBar);
            homeNavigationService.Navigate();
            mainWindow.DataContext = new mainViewModel(navigationStore);
            mainWindow.Show();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.cmbAuthenticationType.SelectedItem.ToString().Contains("SQl Server Authentification"))
            {
                this.ServerViewModel.SetEnable = true;
            }
        }

        private void Cmbdatabase_DropDownOpened(object sender, EventArgs e)
        {
            int icount = 0;

            this.Cmbdatabase.Items.Clear();
            try
            {
                if (cmbAuthenticationType.Text.Equals("Windows Authentication"))
                {
                    this.ServerViewModel.ConnectionString = @"Server = " + this.CmbServername.Text + "; Integrated Security = SSPI;";
                    con.ConnectionString = ServerViewModel.ConnectionString;
                }
                else if (cmbAuthenticationType.Text.Equals("SQL Server Authentication"))
                {
                    this.ServerViewModel.ConnectionString = @"Server = " + this.CmbServername.Text + "; User Id =" + this.Username.Text + "; Password=" + this.Passwort.Text + ";";
                    con.ConnectionString = this.ServerViewModel.ConnectionString;
                }
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT DB_NAME(database_id) AS[Database] FROM sys.databases; ";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    this.ServerViewModel.ListOfDatabases.Insert(icount, dr["Database"].ToString());
                    icount++;
                }

                this.Cmbdatabase.ItemsSource = this.ServerViewModel.ListOfDatabases;
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "OOPSSss!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNewConnectionString()
        {
            ExeConfigurationFileMap oConfigFile = new ExeConfigurationFileMap();
            oConfigFile.ExeConfigFilename = @"~/App.config" ;
            Configuration oConfiguration = ConfigurationManager.OpenMappedExeConfiguration(oConfigFile, ConfigurationUserLevel.None);
            //Define a connection string settings including the name and the connection string
            ConnectionStringSettings oConnectionSettings = new ConnectionStringSettings("ConnectionString", String.Format("{0} {1}", con.ConnectionString, "Initial Catalog =" + this.Cmbdatabase.SelectedItem.ToString()));
            //Adding the connection string to the oConfiguration object
            oConfiguration.ConnectionStrings.ConnectionStrings.Add(oConnectionSettings);
            //Save the new connection string settings
            oConfiguration.Save(ConfigurationSaveMode.Modified);
        }

    }
    
}
