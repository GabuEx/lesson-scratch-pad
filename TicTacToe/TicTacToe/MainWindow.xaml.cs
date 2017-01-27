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
        private Random random = new Random();

        private Button[] squareButtons = null;

        public MainWindow()
        {
            InitializeComponent();

            squareButtons = new Button[]
            {
                TopLeftButton,
                TopMiddleButton,
                TopRightButton,
                MiddleLeftButton,
                MiddleMiddleButton,
                MiddleRightButton,
                BottomLeftButton,
                BottomMiddleButton,
                BottomRightButton,
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            PlayToSquare(senderButton);
            PlayForAI();
        }

        private void PlayToSquare(Button button)
        {
            string winner = "";
            if (playerHasWon)
            {
                return;
            }
            if (button.Content == "")
            {
                if (shouldPlaceAnO)
                {
                    shouldPlaceAnO = false;
                    button.Content = "O";
                }
                else
                {
                    shouldPlaceAnO = true;
                    button.Content = "X";
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

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Restart();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Restart();
            PlayForAI();
        }
        private void PlayForAI()
        {
            Button aiSelectedButton = null;

            do
            {
                aiSelectedButton = squareButtons[random.Next(0, 8)];
            } while (aiSelectedButton.Content != "");

            PlayToSquare(aiSelectedButton);
        }

        private void Restart()
        {
            shouldPlaceAnO = false;
            playerHasWon = false;
            TopLeftButton.Content = "";
            TopMiddleButton.Content = "";
            TopRightButton.Content = "";
            MiddleLeftButton.Content = "";
            MiddleMiddleButton.Content = "";
            MiddleRightButton.Content = "";
            BottomLeftButton.Content = "";
            BottomMiddleButton.Content = "";
            BottomRightButton.Content = "";
            TextDisplay.Text = "";
        }
            private bool CanPlayerWinByPlayingToButton(string player, Button squareButton)
        {
            if (button.Content != "")
            {
                return false;
            }
            if (button == TopLeftButton)
            {
                if (TopMiddleButton.Content == player &&
                    TopRightButton.Content == player)
                {
                    return true;
                }
                else if (MiddleMiddleButton.Content == player &&
                         BottomRightButton.Content == player)
                {
                    return true;
                }
                else if (MiddleLeftButton.Content == player &&
                         BottomLeftButton.Content == player &&)
                {
                    return true;
                }
            }
        }
    }
}
