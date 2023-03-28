namespace StackShuffleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // BUILD DECK
            List<int> originalDeck = new List<int>();
            for(int i = 1; i <= 100; i++)
                originalDeck.Add(i);

            // OUTPUT DECK
            WriteLineDeck(originalDeck);


            var deck = originalDeck;

            bool complete = false;
            int shuffleNumber = 0;
            while (complete == false)
            {
                Console.WriteLine();
                shuffleNumber++;
                Console.WriteLine(String.Format("Shuffle #{0}:", shuffleNumber));
                deck = Shuffle(deck);
                WriteLineDeck(deck);

                if (deck.SequenceEqual(originalDeck))
                    complete = true;
            }

            Console.WriteLine("");
            Console.WriteLine("COMPLETE!!!!");
            Console.WriteLine(shuffleNumber + " Shuffles required");
            Console.WriteLine("");

            Console.ReadLine();
        }


        private static List<int> Shuffle(List<int> deck)
        {
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            var stack3 = new Stack<int>();
            var stack4 = new Stack<int>();

            for(int i = 0; i < deck.Count; i+=4)
            {
                stack1.Push(deck[i]);
                stack2.Push(deck[i+1]);
                stack3.Push(deck[i+2]);
                stack4.Push(deck[i+3]);
            }

            var outputStack = new List<int>();
            outputStack.AddRange(stack4);
            outputStack.AddRange(stack3);
            outputStack.AddRange(stack2);
            outputStack.AddRange(stack1);

            return outputStack;
        }

        private static void WriteLineDeck(List<int> deck)
        {
            foreach (int i in deck)
                Console.Write(String.Format("{0}, ", i));

            Console.WriteLine();                   
        }

    }
}