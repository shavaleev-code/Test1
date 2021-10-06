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

namespace Client.Controls
{
    /// <summary>
    /// Interaction logic for SuccessRegistrationControl.xaml
    /// </summary>
    public partial class SuccessRegistrationControl : UserControl
    {
        public SuccessRegistrationControl()
        {
            InitializeComponent();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "SuccessRegistrationControl", "StartPageControl");           
        }
    }
}
