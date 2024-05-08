using Blackjack.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public int Points { get; set; }
        public bool PlayerTurn { get; set; }

        public int GetHandValue()
        {
            int total = Hand.Sum(c => c.GetValue());
            int numAces = Hand.Where(c => c.Rank == Rank.Ace).Count();

            while (numAces > 0 && total + 10 <= 21)
            {
                total += 10;
                numAces--;
            }

            return total;
        }

        public bool HasBlackjack()
        {
            return Hand.Count == 2 && GetHandValue() == 21;
        }

        public bool HasBusted()
        {
            return GetHandValue() > 21;
        }
    }
}