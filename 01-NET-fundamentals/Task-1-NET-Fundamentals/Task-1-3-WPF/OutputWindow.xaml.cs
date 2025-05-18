using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task_2_ClassLibrary;

namespace Task_1_3_WPF
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        public OutputWindow()
        {
            InitializeComponent();
        }

        private void labelOuput_Loaded(object sender, RoutedEventArgs e)
        {
            var username = EntryMain.username;
            if (string.IsNullOrWhiteSpace(username))
            {
                username = "Mr. Hello World";
            }
            labelOuput.Content = $"Hello, {username}!";
            var outputFromClassLibrary = ConcatenationLogic.WelcomeUser(username);
            labelOutputFromClassLibrary.Content = $"Output from class library: {outputFromClassLibrary}";
        }
    }
}
