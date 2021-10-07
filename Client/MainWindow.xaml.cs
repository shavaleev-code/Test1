using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using Client.Models;

namespace Client
{
    /// <summary>
    /// Interaction logic for AuthorizationWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            this.StartPageControl.Visibility = Visibility.Visible;
            this.RegistrationControl.Visibility = Visibility.Hidden;
            this.AuthorizationControl.Visibility = Visibility.Hidden;
            this.MainUserControl.Visibility = Visibility.Hidden;
            this.ErrorCredentialControl.Visibility = Visibility.Hidden;
            this.ErrorServerControl.Visibility = Visibility.Hidden;
            this.SuccessRegistrationControl.Visibility = Visibility.Hidden;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
