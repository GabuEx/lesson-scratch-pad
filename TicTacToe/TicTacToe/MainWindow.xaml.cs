﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
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
                //Stuff
            }
            else if (MiddleLeftButton.Content != "" &&
                MiddleLeftButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == MiddleRightButton.Content)
            { 
                //Stuff
            }
            else if (BottomLeftButton.Content != "" &&
                BottomLeftButton.Content == BottomMiddleButton.Content &&
                BottomMiddleButton.Content == BottomRightButton.Content)
            {
                //Stuff
            }
            else if (TopLeftButton.Content != "" &&
                TopLeftButton.Content == MiddleLeftButton.Content &&
                MiddleLeftButton.Content == BottomLeftButton.Content)
            {
                //Stuff
            }
            else if (TopMiddleButton.Content != "" &&
                TopMiddleButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == BottomMiddleButton.Content)
            {
                //Stuff
            }
            else if (TopRightButton.Content != "" &&
                TopRightButton.Content == MiddleRightButton.Content &&
                MiddleRightButton.Content == BottomRightButton.Content)
            {
                //Stuff
            }
            else if (TopLeftButton.Content != "" &&
                TopLeftButton.Content == MiddleMiddleButton.Content &&
                MiddleMiddleButton.Content == BottomRightButton.Content)
            {
                //Stuff
            }
            else if (TopRightButton.Content != "" &&
               TopRightButton.Content == MiddleMiddleButton.Content &&
               MiddleMiddleButton.Content == BottomLeftButton.Content)
            {
                //Stuff
            }
        }
    }
}
