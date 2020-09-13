using LogicLayer.Entities;
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
            player.PlayerHand.AddCard();
            player.PlayerHand.AddCard();
            StartBtn.IsEnabled = false;
        }
    }
}
