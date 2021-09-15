using System;
using System.Collections.Generic;
using System.Text;
using static Blackjack_Games.Enum.EFace;
using static Blackjack_Games.Enum.ESuit;

namespace Blackjack_Games.Interface
{
    interface ICard
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }
    }
}
