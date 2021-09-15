using Blackjack_Games.Class;
using Blackjack_Games.Interface;
using System;
using System.Collections.Generic;
using System.Threading;
using static Blackjack_Games.Enum.EFace;

namespace Blackjack_Games
{
    class Program
    {
        //variables and lists       
        static Deck deck;
        static List<ICard> userHand;
        static List<ICard> dealerHand;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "BlackJack";

            deck = new Deck();
            deck.Shuffle();

            do
            {
                Console.Clear();
                Console.WriteLine("BlackJack");
                Console.WriteLine("Do you want to play blackjack Y/N");
                ConsoleKeyInfo play = Console.ReadKey(true);
                while (play.Key != ConsoleKey.Y && play.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid input please choose an option Y or N: ");
                    play = Console.ReadKey(true);
                }


                Console.Clear();
                switch (play.Key)
                {
                    case ConsoleKey.Y:
                        DealHand();
                        Console.WriteLine("Please press a key to continue.");
                        Console.ReadKey(true);
                        //validation = true;
                        continue;

                    case ConsoleKey.N:
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey(true);
                        Console.WriteLine("Thanks for playing.");

                        Thread.Sleep(3000);
                        return;
                }

            } while (true);

        }
        static void DealHand()
        {
            if (deck.GetAmountOfRemainingCrads() < 35)
            {
                deck.Initialize();
                deck.Shuffle();
            }


            userHand = new List<ICard>
            {
                deck.DrawACard(),
                deck.DrawACard()
            };

            foreach (ICard card in userHand)
            {
                if (card.Face == Face.Ace)
                {
                    card.Value += 10;
                    break;
                }
            }

            Console.WriteLine("Remaining Cards: {0}", deck.GetAmountOfRemainingCrads());


            dealerHand = new List<ICard>
            {
                deck.DrawACard(),
                deck.DrawACard()
            };

            foreach (ICard card in dealerHand)
            {
                if (card.Face == Face.Ace)
                {
                    card.Value += 10;
                    break;
                }
            }

            //Outputs dealers hand
            Console.WriteLine("[Dealer]");
            Console.WriteLine("Card 1: {0} of {1}", dealerHand[0].Face, dealerHand[0].Suit);
            Console.WriteLine("Card 2: [Hidden]");
            Console.WriteLine("Total: {0}\n", dealerHand[0].Value);

            //Outputs users hand
            Console.WriteLine("[You]");
            Console.WriteLine("Card 1: {0} of {1}", userHand[0].Face, userHand[0].Suit);
            Console.WriteLine("Card 2: {0} of {1}", userHand[1].Face, userHand[1].Suit);
            Console.WriteLine("Total: {0}\n", userHand[0].Value + userHand[1].Value);

            if (userHand[0].Value + userHand[1].Value == 21)

            {
                if (dealerHand[0].Value + dealerHand[1].Value == 21)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("The dealer and you both got a blackjack, its a draw!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Blackjack, You Won!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                return;
            }

            do
            {
                Console.WriteLine("Would you like to (S)tick or (H)it?");
                ConsoleKeyInfo userOption = Console.ReadKey(true);
                while (userOption.Key != ConsoleKey.H && userOption.Key != ConsoleKey.S)
                {
                    Console.WriteLine("Please choose an option s or h: ");
                    userOption = Console.ReadKey(true);
                }
                Thread.Sleep(200);
                Console.Clear();
                switch (userOption.Key)
                {
                    case ConsoleKey.H:
                        userHand.Add(deck.DrawACard());
                        Console.WriteLine("Hitted {0} of {1}", userHand[userHand.Count - 1].Face, userHand[userHand.Count - 1].Suit);
                        int totalCardsValue = 0;

                        foreach (ICard card in userHand)
                        {
                            totalCardsValue += card.Value;
                        }

                        Console.WriteLine("Total cards value now: {0}\n", totalCardsValue);

                        if (totalCardsValue > 21)
                        {

                            Console.WriteLine("Bust!");
                            Console.WriteLine("You lost better luck next time.");

                            return;
                        }

                        else
                        {
                            continue;
                        }


                    case ConsoleKey.S:
                        Console.WriteLine("[Dealer]");
                        Console.WriteLine("Card 1: {0} of {1}", dealerHand[0].Face, dealerHand[0].Suit);
                        Console.WriteLine("Card 2: {0} of {1}", dealerHand[1].Face, dealerHand[1].Suit);

                        int dealerCardsValue = 0;
                        foreach (ICard card in dealerHand)
                        {
                            dealerCardsValue += card.Value;
                        }
                        int playerCardValue = 0;
                        foreach (ICard card in userHand)
                        {
                            playerCardValue += card.Value;
                        }


                        while (dealerCardsValue <= playerCardValue)
                        {
                            dealerHand.Add(deck.DrawACard());
                            dealerCardsValue = 0;

                            foreach (ICard card in dealerHand)
                            {
                                dealerCardsValue += card.Value;
                            }

                            Console.WriteLine("Card {0}: {1} of {2}", dealerHand.Count, dealerHand[dealerHand.Count - 1].Face, dealerHand[dealerHand.Count - 1].Suit);
                        }

                        dealerCardsValue = 0;
                        foreach (ICard card in dealerHand)
                        {
                            dealerCardsValue += card.Value;
                        }

                        Console.WriteLine("Total: {0}\n", dealerCardsValue);

                        if (dealerCardsValue > 21)
                        {

                            Console.WriteLine("Dealer bust! You win! ");

                            return;
                        }

                        else
                        {


                            if (dealerCardsValue > playerCardValue)
                            {

                                Console.WriteLine("The dealers value {0} and your value is {1}, dealer wins!", dealerCardsValue, playerCardValue);
                                Console.WriteLine("Better luck next time!!!");

                                return;
                            }

                            else if (dealerCardsValue == playerCardValue)
                            {

                                Console.WriteLine("The dealers value is {0} and your value is {1}, its a draw!", dealerCardsValue, playerCardValue);

                                return;
                            }

                            else
                            {

                                Console.WriteLine("Your value is {0} and dealers value is {1}, you win!", playerCardValue, dealerCardsValue);

                                return;
                            }
                        }
                }
                Console.ReadLine();
            }
            while (true);
        }

    }

}
