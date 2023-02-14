using EngineeringToolsCV_1.Models;
using EngineeringToolsCV_1.Repositories;
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
    /// Interaktionslogik für PageInformation.xaml
    /// </summary>
    public partial class InformationView : UserControl
    {
        private UserInfosRepositories userInfosRepositories;
        private MStudentInformations mStudentInformations;

        public InformationView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           this.userInfosRepositories = new UserInfosRepositories();
           this.    mStudentInformations = new MStudentInformations();

        }
    }
}
