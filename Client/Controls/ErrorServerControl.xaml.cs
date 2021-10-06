using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public partial class ErrorServerControl : UserControl
    {
        public ErrorServerControl()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ControlsMethods.SwitchControls(Window.GetWindow(this), "ErrorServerControl", "StartPageControl");           
        }
    }
}
