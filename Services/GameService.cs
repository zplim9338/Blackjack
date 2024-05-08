using Blackjack.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Services
{
    public class GameService
    {
        private Deck deck;
        private List<Player> players;
        private List<Player> remainingPlayers;
        private Player dealer;
        private readonly int defaultPoint = 1000;

        public void InitGame()
        {
            deck = new Deck();
            players = new List<Player>();
            dealer = new Player()
            {
                Points = defaultPoint,
                Name = "Dealer"
            };
        }

        public void NewRound()
        {
            deck = new Deck();
            StartGame();
        }

        public void StartGame()
        {
            remainingPlayers = players.Select(x => x).ToList(); //Deep copy 1 set data to check the player who havent hit

            foreach (Player p in players)
            {
                p.Hand = new List<Card>
                {
                    deck.Deal(),
                    deck.Deal()
                };
            }

            dealer.Hand = new List<Card> {
                deck.Deal(),
                deck.Deal()
            };

            this.ValidatePlayersInitCards();
            this.UpdatePlayerTurn();
        }

        public bool ValidateStartGame(ref string msg)
        {
            if (!players.Any())
            {
                msg = "Please add at least 1 player.";
                return false;
            }
            return true;
        }

        public Player AddPlayer(string name)
        {
            Player player = new Player()
            {
                Points = defaultPoint,
                Name = name,
                PlayerTurn = false
            };
            players.Add(player);

            return player;
        }

        public bool ValidateAddPlayer(ref string msg, string name)
        {
            if (name == string.Empty)
            {
                msg = "Please key in name.";
                return false;
            }

            if (players.Any(p => p.Name == name))
            {
                msg = "Player already exists.";
                return false;
            }

            return true;
        }

        public Player GetDealer()
        {
            return dealer;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public int GetDeckCardsCount()
        {
            return deck.GetCardsCount();
        }

        public void ValidatePlayerDeal(ref string msg, Player player)
        {
            if (player.HasBusted())
            {
                msg = "Busted!!";
                remainingPlayers.Remove(player);
                this.UpdatePlayerTurn();
                return;
            }

            if (player.HasBlackjack())
            {
                msg = "Black Jack!!";
                remainingPlayers.Remove(player);
                this.UpdatePlayerTurn();
                return;
            }
        }

        public void ValidateDealerDeal(ref string msg)
        {
            if (dealer.HasBusted())
            {
                msg = "Busted!!";
                return;
            }

            if (dealer.HasBlackjack())
            {
                msg = "Black Jack!!";
                return;
            }
        }

        public void PlayerHit(Player player)
        {
            player.Hand.Add(deck.Deal());
        }

        public void PlayerStay(Player player)
        {
            remainingPlayers.Remove(player);

            this.UpdatePlayerTurn();
        }

        public Player GetCurrentTurnPlayer()
        {
            return players.Where(x => x.PlayerTurn).FirstOrDefault();
        }

        public int GetRemainingPlayerCount()
        {
            return remainingPlayers.Count;
        }

        public void DealerTurn()
        {
            while (dealer.GetHandValue() < 16)
            {
                dealer.Hand.Add(deck.Deal());
            }
        }

        public void CalculatePlayerPoint()
        {
            int dealerTotal = dealer.GetHandValue();
            foreach (Player p in players)
            {
                int playerTotal = p.GetHandValue();
                if (p.HasBusted())
                {
                    p.Points -= 10;
                }
                else if (dealer.HasBusted() || playerTotal > dealerTotal)
                {
                    p.Points += p.HasBlackjack() ? 15 : 10;
                }
                else if (dealerTotal > playerTotal)
                {
                    p.Points -= 10;
                }
                else
                {
                    //draw
                }

            }
        }

        private void ValidatePlayersInitCards()
        {
            foreach (Player p in players)
            {
                if (p.HasBlackjack())
                {
                    remainingPlayers.Remove(p);
                }
            }
        }

        private void UpdatePlayerTurn()
        {
            players.ForEach(p => p.PlayerTurn = false);
            if (remainingPlayers.Count > 0)
            {
                Player player = players.FirstOrDefault(p => p.Name == remainingPlayers[0].Name);
                if (player != null)
                {
                    player.PlayerTurn = true;
                }
            }
        }
    }
}