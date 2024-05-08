using Blackjack.Models;
using Blackjack.Services;
using Blackjack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Blackjack
{
    public partial class GameForm : Form
    {
        GameService gameSvc;
        bool gameStarted;

        public GameForm()
        {
            InitializeComponent();
            try
            {
                this.InitGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (gameStarted)
                {
                    MessageBox.Show("Game already started");
                    return;
                }

                string msg = string.Empty;
                bool status = gameSvc.ValidateStartGame(ref msg);

                if (status)
                {
                    gameSvc.StartGame();
                    gameStarted = status;
                    this.UpdateGameState();

                    if (gameSvc.GetRemainingPlayerCount() == 0)
                    {
                        this.RunDealerTurn();
                        this.RefreshScoringBoard();
                    }
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (gameStarted) { return; }

                string playerName = txtPlayerName.Text.Trim();
                string msg = string.Empty;
                bool status = gameSvc.ValidateAddPlayer(ref msg, playerName);

                if (status)
                {
                    Player player = gameSvc.AddPlayer(playerName);
                    lsScoringBoard.Items.Add(player.Name + " : " + player.Points);
                    txtPlayerName.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnHit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gameStarted) { return; }

                Player player = gameSvc.GetCurrentTurnPlayer();

                if (player == null) { return; }

                string msg = string.Empty;

                gameSvc.PlayerHit(player);

                gameSvc.ValidatePlayerDeal(ref msg, player);

                this.UpdateGameState();

                if (msg != string.Empty)
                {
                    MessageBox.Show(msg);
                }

                if (gameSvc.GetRemainingPlayerCount() == 0)
                {
                    this.RunDealerTurn();
                    this.RefreshScoringBoard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gameStarted) { return; }

                Player player = gameSvc.GetCurrentTurnPlayer();

                if (player == null) { return; }

                gameSvc.PlayerStay(player);

                this.UpdateGameState();

                if (gameSvc.GetRemainingPlayerCount() == 0)
                {
                    this.RunDealerTurn();
                    this.RefreshScoringBoard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNewRound_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gameStarted) { return; }

                lsGameState.Clear();
                gameSvc.NewRound();
                this.UpdateGameState();

                if (gameSvc.GetRemainingPlayerCount() == 0)
                {
                    this.RunDealerTurn();
                    this.RefreshScoringBoard();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.InitGame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitGame()
        {
            gameSvc = new GameService();
            gameSvc.InitGame();
            gameStarted = false;
            lsScoringBoard.Clear();
            lsGameState.Clear();
        }

        private void UpdateGameState()
        {
            lsGameState.Items.Clear();
            Player dealer = gameSvc.GetDealer();
            List<Player> players = gameSvc.GetPlayers();

            //Update Deck Card Count
            txtDeckCardsCount.Text = gameSvc.GetDeckCardsCount().ToString();

            //DEALER GAME STATE
            lsGameState.Items.Add("🖥️ " + dealer.Name);
            if (players.Any(p => p.PlayerTurn))
            {
                lsGameState.Items.Add(EnumExtensions.GetDescription(dealer.Hand[0].Rank) + EnumExtensions.GetDescription(dealer.Hand[0].Suit));
                lsGameState.Items.Add("[?]");
            }
            else
            {
                foreach (var card in dealer.Hand)
                {
                    lsGameState.Items.Add(EnumExtensions.GetDescription(card.Rank) + EnumExtensions.GetDescription(card.Suit));
                }
            }
            lsGameState.Items.Add(string.Empty);
            lsGameState.Items.Add(string.Empty);

            //PLAYER GAME STATE
            foreach (Player p in players)
            {
                lsGameState.Items.Add("👤 " + p.Name + (p.PlayerTurn ? " ◀" : string.Empty));

                foreach (var card in p.Hand)
                {
                    lsGameState.Items.Add(EnumExtensions.GetDescription(card.Rank) + EnumExtensions.GetDescription(card.Suit));
                }
                lsGameState.Items.Add(string.Empty);
                lsGameState.Items.Add(string.Empty);
            }
        }

        private void RunDealerTurn()
        {
            string msg = string.Empty;

            gameSvc.DealerTurn();

            gameSvc.ValidateDealerDeal(ref msg);

            this.UpdateGameState();

            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
            }
        }

        private void RefreshScoringBoard()
        {
            gameSvc.CalculatePlayerPoint();

            lsScoringBoard.Clear();
            List<Player> players = gameSvc.GetPlayers();
            foreach (Player p in players)
            {
                lsScoringBoard.Items.Add(p.Name + " : " + p.Points);
            }

            MessageBox.Show("Round ended. Player's score updated.");
        }
    }
}