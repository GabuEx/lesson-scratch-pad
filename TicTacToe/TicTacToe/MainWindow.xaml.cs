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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool shouldPlaceAnO = false;
        private bool playerHasWon = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            string winner = "";
            if (playerHasWon)
            {
                return;
            }
            if (senderButton.Content == "")
            {
                if (shouldPlaceAnO)
                {
                    shouldPlaceAnO = false;
                    senderButton.Content = "O";
                }
                else
                {
                    shouldPlaceAnO = true;
                    senderButton.Content = "X";
                }
            }
            if (TopLeftButton.Content != "" &&
                TopLeftButton.Content == TopMiddleButton.Content &&
                TopMiddleButton.Content == TopRightButton.Content)
            {
                winner = TopLeftButton.Content as string;
            }
            else if (MiddleLeftButton.Content != "" &&
                MiddleLeftButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == MiddleRightButton.Content)
            {
                winner = MiddleLeftButton.Content as string;
            }
            else if (BottomLeftButton.Content != "" &&
                BottomLeftButton.Content == BottomMiddleButton.Content &&
                BottomMiddleButton.Content == BottomRightButton.Content)
            {
                winner = BottomLeftButton.Content as string;
            }
            else if (TopLeftButton.Content != "" &&
                TopLeftButton.Content == MiddleLeftButton.Content &&
                MiddleLeftButton.Content == BottomLeftButton.Content)
            {
                winner = TopLeftButton.Content as string;
            }
            else if (TopMiddleButton.Content != "" &&
                TopMiddleButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == BottomMiddleButton.Content)
            {
                winner = TopMiddleButton.Content as string;
            }
            else if (TopRightButton.Content != "" &&
                TopRightButton.Content == MiddleRightButton.Content &&
                MiddleRightButton.Content == BottomRightButton.Content)
            {
                winner = TopRightButton.Content as string;
            }
            else if (TopLeftButton.Content != "" &&
                TopLeftButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == BottomRightButton.Content)
            {
                winner = TopLeftButton.Content as string;
            }
            else if (TopRightButton.Content != "" &&
               TopRightButton.Content == MiddleMiddleButton.Content &&
               MiddleMiddleButton.Content == BottomLeftButton.Content)
            {
                winner = TopRightButton.Content as string;
            }
            if (winner == "X")
            {
                TextDisplay.Text = "X wins!";
                playerHasWon = true;
            }
            else if (winner == "O")
            {
                TextDisplay.Text = "O wins!";
                playerHasWon = true;
            }
        }
    }
}
