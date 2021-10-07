using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Client.Controls
{
    public static class ControlsMethods
    {
        //Метод, для навигации контролов в окне
        public static void SwitchControls(Window window, string controlCurrent, string controlToReplace)
        {
            if (null != window)
            {
                ((UserControl)window.FindName(controlCurrent)).Visibility = Visibility.Hidden;
                ((UserControl)window.FindName(controlToReplace)).Visibility = Visibility.Visible;
            }
        }
    }
}
