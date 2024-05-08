using Blackjack.Enums;
using System;

namespace Blackjack.Models
{
    public class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int GetValue()
        {
            if (Rank >= Rank.Ten)
            {
                return 10;
            }
            else
            {
                return (int)Rank;
            }
        }
    }
}