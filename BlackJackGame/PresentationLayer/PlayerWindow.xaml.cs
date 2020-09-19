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
            this.Title ="Player " + localPlayer.PlayerId.ToString();
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            if (localPlayer.IsThick)
            {
                PlayerIsThick.Content = "Sorry your hand is too big";
                StayBtn.IsEnabled = false;
                PlayerDrawCard.IsEnabled = false;
            }
        }

        /// <summary>
        /// Event listners for the player
        /// </summary>
        public event EventHandler<Player> hitEvent;
        public event EventHandler<Player> stayEvent;

        private void PlayerDrawCard_Click(object sender, RoutedEventArgs e)
        {
            OnHitEvent(localPlayer);
            PlayerHandListBox.Items.Clear();
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            if (localPlayer.IsThick)
            {
                PlayerDrawCard.IsEnabled = false;
                OnStayEvent(localPlayer);
                PlayerIsThick.Content = "Sorry you are thick! \n Good luck next round! ";
            }
        }

        private void StayBtn_Click(object sender, RoutedEventArgs e)
        {
            localPlayer.IsFinished = true;
            PlayerDrawCard.IsEnabled = false;
            StayBtn.IsEnabled = false;
            OnStayEvent(localPlayer);
        }

        public void OnHitEvent(Player e)
        {
            if (hitEvent != null)
            {
                hitEvent(this, e);
            }
        }

        public void OnStayEvent(Player e)
        {
            if (stayEvent != null)
            {
                stayEvent(this, e);
            }
        }


    }
}
