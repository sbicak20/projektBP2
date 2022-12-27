using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BP2projekt
{
    internal static class GuiManager
    {
        public static MainWindow mainWindow { get; set; }

        private static UserControl previous;

        public static void OpenContent(UserControl userControl)
        {
            previous = mainWindow.controlPanel.Content as UserControl;
            mainWindow.controlPanel.Content = userControl;
        }

        public static void CloseContent()
        {
            mainWindow.controlPanel.Content = previous;
        }
    }
}
