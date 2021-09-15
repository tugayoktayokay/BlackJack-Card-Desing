using Blackjack_Games.Enum;
using Blackjack_Games.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static Blackjack_Games.Enum.EFace;
using static Blackjack_Games.Enum.ESuit;

namespace Blackjack_Games.Class
{
    class Card:ICard
    {
        public  int Value { get; set; }
        public Suit Suit { get; set; }
        public Face Face { get; set; }
    }
}
