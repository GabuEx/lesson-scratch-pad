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
        private int firstNumber = 0;
        private string operation = "";
        private bool shouldStartNewNumber = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            if (this.NumberDisplay.Text == "0" || shouldStartNewNumber)
            {
                //Do stuff when text is "0"
                this.NumberDisplay.Text = senderButton.Content as string;
                shouldStartNewNumber = false;
            }
            else
            {
                //Do stuff when text isn't "0"
                this.NumberDisplay.Text += senderButton.Content;
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            this.NumberDisplay2.Text = senderButton.Content as string;
            firstNumber = int.Parse(this.NumberDisplay.Text);
            operation = senderButton.Content as string;
            shouldStartNewNumber = true;
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            int secondNumber = int.Parse(this.NumberDisplay.Text);
            if (operation == "+")
            {
                secondNumber = firstNumber + secondNumber;
            }
            else if(operation == "-")
            {
                secondNumber = firstNumber - secondNumber;
            }
            else if (operation == "x")
            {
                secondNumber = firstNumber * secondNumber;
            }
            else if(operation == "/")
            {
                secondNumber = firstNumber / secondNumber;
            }
            this.NumberDisplay.Text = secondNumber.ToString();
        }
    }
}
