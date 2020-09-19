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

        //public event EventHandler<Player> NewCard;


        public MainWindow()
        {
            InitializeComponent();
            deck.InitializeDeck();
            deck.Shuffle();
            
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Players.Text != null && Decks.Text != null)
            {
                game.AddPlayers(Int32.Parse(Players.Text));
                game.CreateDeck(Int32.Parse(Decks.Text));
                game.PlayerStartHand();
                game.ArePlayersThick();
                
            }

            if (game.Players.Count >= 1)
            {
                foreach (var player in game.Players)
                {
                    PlayerWindow playerWindow = new PlayerWindow(player);
                    playerWindow.Show();
                    playerWindow.hitEvent += OnHitEvent;
                    playerWindow.stayEvent += OnStayEvent;
                }

                DealerScore.Content = game.Dealer.PlayerHand.Score;
                DealerCardsListBox.Items.Add(game.Dealer.PlayerHand.ToString());
                DealerScore.IsEnabled = true;
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
                UpDateDealerData();
            }
        }

        private void DealerDrawBtn_Click(object sender, RoutedEventArgs e)
        {
            game.DealerDrawCard();
            UpDateDealerData();
            game.ArePlayersThick();
            if (game.Dealer.IsThick)
            {
                DealerDrawBtn.IsEnabled = false;
                DealerInfoLabel.Content = "The dealer is thick!";
            }
        }

        /// <summary>
        /// Method to update labels and buttons for the dealer
        /// </summary>
        public void UpDateDealerData()
        {
            DealerCardsListBox.Items.Clear();
            DealerScore.Content = game.Dealer.PlayerHand.Score;
            DealerCardsListBox.Items.Add(game.Dealer.PlayerHand.ToString());
        }

        private void DealerStayBtn_Click(object sender, RoutedEventArgs e)
        {
            WinnerListBox.Visibility = Visibility.Visible;
            WinnerListBox.Items.Add(game.EvaluateWhoWon());
        }
    }
}
