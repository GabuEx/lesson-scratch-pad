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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            if (this.NumberDisplay.Text == "0")
            {
                //Do stuff when text is "0"
                this.NumberDisplay.Text = senderButton.Content as string;
            }
            else
            {
                //Do stuff when text isn't "0"
                this.NumberDisplay.Text += senderButton.Content;
            }
        }
    }
}
