using Blackjack_Games.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static Blackjack_Games.Enum.EFace;
using static Blackjack_Games.Enum.ESuit;

namespace Blackjack_Games.Class
{
    class Deck
    {
        private List<ICard> cards;

        public Deck()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            cards = new List<ICard>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    cards.Add(new Card() { Suit = (Suit)i, Face = (Face)j });

                    if (j <= 8)
                        cards[^1].Value = j + 1;
                    else
                        cards[^1].Value = 10;
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ICard card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }

        public ICard DrawACard()
        {
            if (cards.Count <= 0)
            {
                this.Initialize();
                this.Shuffle();
            }

            ICard cardToReturn = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return cardToReturn;
        }

        public int GetAmountOfRemainingCrads()
        {
            return cards.Count;
        }

        public void PrintDeck()
        {
            int i = 1;
            foreach (ICard card in cards)
            {
                Console.WriteLine("Card {0}: {1} of {2}. Value: {3}", i, card.Face, card.Suit, card.Value);
                i++;
            }
        }
    }
}
