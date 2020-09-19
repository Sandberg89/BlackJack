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

        public event EventHandler<Player> NewCard;


        public MainWindow()
        {
            InitializeComponent();
            deck.InitializeDeck();
            deck.Shuffle();
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                }

                DealerScore.Content = game.Dealer.PlayerHand.Score;
                DealerScore.IsEnabled = true;
                StartBtn.IsEnabled = false;
                Players.IsEnabled = false;
                Decks.IsEnabled = false;

            }

            else
            {
                MessageBox.Show("Must add at least one player!");
            }


        }

        public void OnHitEvent(object sender, Player e)
        {
            game.PlayerDrawCard(e);
        }
    }
}
