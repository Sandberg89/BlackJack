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
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        Player localPlayer;

        public PlayerWindow(Player player)
        {
            InitializeComponent();
            localPlayer = player;
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            if (localPlayer.IsThick)
            {
                PlayerIsThick.Content = "Sorry your hand is too big";
                PlayerDrawCard.IsEnabled = false;
            }
        }

        public event EventHandler<Player> hitEvent;

        private void PlayerDrawCard_Click(object sender, RoutedEventArgs e)
        {
            OnHitEvent(localPlayer);
            PlayerHandListBox.Items.Clear();
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            if (localPlayer.IsThick)
            {
                PlayerDrawCard.IsEnabled = false;
                PlayerIsThick.Content = "Sorry you are thick!";
            }
        }

        public void OnHitEvent(Player e)
        {
            if (hitEvent != null)
            {
                hitEvent(this, e);
            }
        }
    }
}
