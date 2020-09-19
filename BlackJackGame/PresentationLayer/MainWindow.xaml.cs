using LogicLayer.Entities;
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
        GameUtils game = new GameUtils();
        PlayerWindow playerWindow;


        public MainWindow()
        {
            InitializeComponent();
            deck.InitializeDeck();
            deck.Shuffle();

        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Players.Text != null && Decks.Text != null)
            {
                game.AddPlayers(Int32.Parse(Players.Text));
                game.CreateDeck(Int32.Parse(Decks.Text));
                game.PlayerStartHand();
                game.ArePlayersThick();
                StartNewRound();
            }

        }

        private void StartNewRound()
        {

            if (game.Players.Count >= 1)
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
                Players.IsEnabled = false;
                Decks.IsEnabled = false;
                ShuffleBtn.IsEnabled = true;
            }

            else
            {
                MessageBox.Show("Must add at least one player!");
            }
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
        /// Draw a new card and check if the player is thick 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnHitEvent(object sender, Player e)
        {
            game.PlayerDrawCard(e);
            game.ArePlayersThick();
        }

        /// <summary>
        /// Check and see if all players are done 
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

        private void DealerStayBtn_Click(object sender, RoutedEventArgs e)
        {
            WinnerListBox.Visibility = Visibility.Visible;
            WinLabel.Visibility = Visibility.Visible;
            WinnerListBox.Items.Add(game.EvaluateWhoWon());
            DealerDrawBtn.IsEnabled = false;
            DealerStayBtn.IsEnabled = false;
        }

        private void NewRoundBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check cards in deck
            CloseAllWindows();
            ResetUiComponents();
            game.ResetRound();
            if (game.DeckLessThanOneFourth())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to shuffle the cards?", "Shuffle cards", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        game.CreateDeck(Int32.Parse(Decks.Text));
                        break;
                }
            }
            game.PlayerStartHand();
            game.ArePlayersThick();
            StartNewRound();


        }
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
    }

