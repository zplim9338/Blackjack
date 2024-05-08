using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    public class Deck
    {
        private const int ReshuffleThreshold = 15;
        private List<Card> cards;
        private Random rand;

        public Deck()
        {
            cards = this.GenerateDeck();
            rand = new Random();
            this.Shuffle();
        }

        public Card Deal()
        {
            if (cards.Count < ReshuffleThreshold)
            {
                this.Shuffle();
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        private List<Card> GenerateDeck()
        {
            var deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        private void Shuffle()
        {
            cards = cards.OrderBy(c => rand.Next()).ToList();
        }

        public int GetCardsCount()
        {
            return cards.Count();
        }
    }
}