// Name: Linus Sandberg. Date: 2020-09-20. Project: Black Jack Game Assignment 1
using LogicLayer.Entities;
using Utilities;
using LogicLayer.Enums;
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
using System.Text.RegularExpressions;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player = new Player();
        Deck deck = new Deck(1);
        Utils game = new Utils();
        PlayerWindow playerWindow;

        /// <summary>
        /// Initiailize a new window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Set values and start a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersTextbox.Text != "" && DecksTextBox.Text != "" && int.Parse(PlayersTextbox.Text) >= 1 && int.Parse(DecksTextBox.Text) >= 1 )
            {
                game.AddPlayers(Int32.Parse(PlayersTextbox.Text));
                game.CreateDeck(Int32.Parse(DecksTextBox.Text));
                game.PlayerStartHand();
                game.ArePlayersThick();
                StartNewRound();
            }
            else
            {
                MessageBox.Show("Must add at least one player and one deck!");
            }

        }

        /// <summary>
        /// Methods that initiate new players and handle UI components
        /// </summary>
        private void StartNewRound()
        {
             foreach (var player in game.Players)
             {
                 playerWindow = new PlayerWindow(player);
                 playerWindow.hitEvent += OnHitEvent;
                 playerWindow.stayEvent += OnStayEvent;
                 playerWindow.Show();
             }

             DealerScoreLabel.Content = game.Dealer.PlayerHand.Score;
             DealerCardsListBox.Items.Add(game.Dealer.PlayerHand.ToString());
             DealerScoreLabel.IsEnabled = true;
             StartBtn.IsEnabled = false;
             PlayersTextbox.IsEnabled = false;
             DecksTextBox.IsEnabled = false;
             ShuffleBtn.IsEnabled = true;
             NewRoundBtn.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Shuffle the deck when user click on btn 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShuffleBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ReshuffleDeck();
        }

        /// <summary>
        /// Event for when a player draw a new card 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnHitEvent(object sender, Player e)
        {
            game.PlayerDrawCard(e);
            game.ArePlayersThick();
        }

        /// <summary>
        /// Event that checks if all the players have stayed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnStayEvent(object sender, Player e)
        {
            if (game.AllPlayersDone())
            {

                DealerDrawBtn.Visibility = Visibility.Visible;
                DealerStayBtn.Visibility = Visibility.Visible;
                DealerDrawBtn.IsEnabled = true;
                DealerStayBtn.IsEnabled = true;
                game.ArePlayersThick();
                game.IsDealerThick();
                UpDateDealerData();
            }
        }

        /// <summary>
        /// Dealer draw button that draw a card and check if dealer is Thick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealerDrawBtn_Click(object sender, RoutedEventArgs e)
        {
            game.DealerDrawCard();
            game.IsDealerThick();
            UpDateDealerData();
            
        }

        /// <summary>
        /// Method to update labels and buttons for the dealer
        /// </summary>
        public void UpDateDealerData()
        {
            DealerCardsListBox.Items.Clear();
            DealerScoreLabel.Content = game.Dealer.PlayerHand.Score;
            DealerCardsListBox.Items.Add(game.Dealer.PlayerHand.ToString());
            if (game.Dealer.IsThick)
            {
                DealerDrawBtn.IsEnabled = false;
                DealerInfoLabel.Content = "The dealer is thick!";
            }
            else
            {
                DealerInfoLabel.Content = "";
            }

        }

        /// <summary>
        /// Button click event for when the dealer stay 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealerStayBtn_Click(object sender, RoutedEventArgs e)
        {
            WinnerListBox.Visibility = Visibility.Visible;
            WinLabel.Visibility = Visibility.Visible;
            WinnerListBox.Items.Add(game.EvaluateWhoWon());
            DealerDrawBtn.IsEnabled = false;
            DealerStayBtn.IsEnabled = false;
        }

        /// <summary>
        /// Button that initiate a new round
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewRoundBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseAllWindows();
            ResetUiComponents();
            game.ResetRound();
            if (game.DeckLessThanOneFourth())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to shuffle the cards?", "Shuffle cards", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        game.CreateDeck(Int32.Parse(DecksTextBox.Text));
                        break;
                }
            }
            game.PlayerStartHand();
            game.ArePlayersThick();
            StartNewRound();


        }

        /// <summary>
        /// Method for resetting some UI components
        /// </summary>
        public void ResetUiComponents()
        {
            DealerCardsListBox.Items.Clear();
            WinnerListBox.Items.Clear();
        }

        /// <summary>
        /// Method to class all open windows 
        /// </summary>
        private void CloseAllWindows()
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter > 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        /// <summary>
        /// Method that validate input for Textbox player and deck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
    }

