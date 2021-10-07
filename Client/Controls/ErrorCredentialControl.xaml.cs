using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public partial class ErrorCredentialControl : UserControl
    {
        public ErrorCredentialControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "ErrorCredentialControl", "StartPageControl");            
        }
    }
}
