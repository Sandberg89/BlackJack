// Name: Linus Sandberg. Date: 2020-09-20. Project: Black Jack Game Assignment 1
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
        /// <summary>
        /// Event listners for the player
        /// </summary>
        Player localPlayer;
        public event EventHandler<Player> hitEvent;
        public event EventHandler<Player> stayEvent;
        
        /// <summary>
        /// Initiate a new window
        /// </summary>
        /// <param name="player"></param>
        public PlayerWindow(Player player)
        {
            InitializeComponent();
            localPlayer = player;
            this.Title ="Player " + localPlayer.PlayerId.ToString();
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            CheckPlayer();
        }
        
        /// <summary>
        /// Method for when player draw a card also update UI components
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerDrawCard_Click(object sender, RoutedEventArgs e)
        {
            OnHitEvent(localPlayer);
            PlayerHandListBox.Items.Clear();
            PlayerHandValue.Content = localPlayer.PlayerHand.Score;
            PlayerHandListBox.Items.Add(localPlayer.PlayerHand.ToString());
            CheckPlayer();
        }

        /// <summary>
        /// Check if the player is Thick and update the UI if that is the case
        /// </summary>
        private void CheckPlayer()
        {
            if (localPlayer.IsThick)
            {
                PlayerDrawCard.IsEnabled = false;
               // StayBtn.IsEnabled = false;
                OnStayEvent(localPlayer);
                PlayerIsThick.Content = "Sorry you are thick! \n Good luck next round! ";
            }
        }

        /// <summary>
        /// Button click for when the player is Done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StayBtn_Click(object sender, RoutedEventArgs e)
        {
            localPlayer.IsFinished = true;
            PlayerDrawCard.IsEnabled = false;
            StayBtn.IsEnabled = false;
            OnStayEvent(localPlayer);
        }

        /// <summary>
        /// Send event when the player draw a card
        /// </summary>
        /// <param name="e"></param>
        public void OnHitEvent(Player e)
        {
            if (hitEvent != null)
            {
                hitEvent(this, e);
            }
        }

        /// <summary>
        /// Send event when the player stays
        /// </summary>
        /// <param name="e"></param>
        public void OnStayEvent(Player e)
        {
            if (stayEvent != null)
            {
                stayEvent(this, e);
            }
        }


    }
}
