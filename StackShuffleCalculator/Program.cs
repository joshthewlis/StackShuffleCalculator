using System.Diagnostics;

namespace StackShuffleCalculator
{
    internal class Program
    {
        static int numberOfCards = 0;
        static int numberOfStacks = 0;

        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("JTs Stack/Pile Shuffle Calculator!");

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            // Number of Cards
            Console.WriteLine("Please enter the number of cards in the deck:");
            while (numberOfCards <= 0)
            {
                int.TryParse(Console.ReadLine(), out numberOfCards);

                if (numberOfCards == 0)
                {
                    Console.WriteLine("Oh dear! That is an incorrect input. Please try again:");
                }
            }

            // Number of Stacks
            Console.WriteLine("Please enter the number of stacks:");
            while (numberOfStacks <= 0)
            {
                int.TryParse(Console.ReadLine(), out numberOfStacks);

                if (numberOfStacks == 0)
                {
                    Console.WriteLine("Oh dear! That is an incorrect input. Please try again:");
                }
            }


            // BUILD DECK
            List<int> originalDeck = new List<int>();
            for (int i = 1; i <= numberOfCards; i++)
                originalDeck.Add(i);

            // OUTPUT DECK
            Console.WriteLine("Original Deck Order:");
            WriteLineDeck(originalDeck);

            // BUILD PLAY DECK
            var deck = originalDeck;

            // LETS SHUFFLE
            // START TIMER
            stopwatch.Start();

            bool complete = false;
            int shuffleNumber = 0;
            while (complete == false)
            {
                Console.WriteLine();
                shuffleNumber++;
                Console.WriteLine("Shuffle #{0}:", shuffleNumber);
                deck = Shuffle(deck);
                WriteLineDeck(deck);

                if (deck.SequenceEqual(originalDeck))
                    complete = true;
            }

            stopwatch.Stop();

            // SHUFFLE COMPLETE
            Console.WriteLine("");
            Console.WriteLine("COMPLETE!!!!");
            Console.WriteLine("{0} Shuffles required", shuffleNumber);
            Console.WriteLine("Solution found in {0} milliseconds", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("");

            // READ KEY FOR USER TO VIEW RESULTS
            Console.ReadLine();
        }


        private static List<int> Shuffle(List<int> deck)
        {
            var stacks = new Stack<int>[numberOfStacks];

            // INITALIZE MY STACKS
            for (int i = 0; i < numberOfStacks; i++)
                stacks[i] = new Stack<int>();

            int stackNumber = 0;

            for (int i = 0; i < deck.Count; i++)
            {
                stacks[stackNumber].Push(deck[i]);
                stackNumber++;

                if (stackNumber > stacks.Length - 1)
                    stackNumber = 0;
            }

            var outputStack = new List<int>();
            for (int i = stacks.Length - 1; i >= 0; i--)
                outputStack.AddRange(stacks[i]);

            return outputStack;
        }

        private static void WriteLineDeck(List<int> deck)
        {
            deck.ForEach(i => Console.Write("{0}, ", i));
            Console.WriteLine();
        }

    }
}