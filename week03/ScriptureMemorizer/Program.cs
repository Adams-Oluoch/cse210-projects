using System;

// I exceeded requirements by:
// 1. Allowing multi-verse scriptures automatically.
// 2. Only hiding words that are NOT already hidden.
// 3. Progress tracking with percentage displayed after each round.
// 4. Difficulty selection (choose how many words to hide each time).
// 5. Scripture statistics showing total words and hidden count.
// 6. Option to reveal a word for help (hint system).

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SCRIPTURE MEMORIZER ===\n");
        
        // Get difficulty level from user
        int wordsToHidePerRound = GetDifficultyLevel();
        
        // Create scripture with multiple verses
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, text);
        
        int roundsCompleted = 0;
        int hintsUsed = 0;

        while (true)
        {
            Console.Clear();
            
            // Display scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            // Show progress tracking and statistics
            double percentage = scripture.GetHiddenPercentage();
            int hiddenCount = scripture.GetHiddenWordCount();
            int totalWords = scripture.GetTotalWordCount();
            
            Console.WriteLine($"Progress: {percentage:F1}% hidden ({hiddenCount}/{totalWords} words)");
            Console.WriteLine($"Rounds completed: {roundsCompleted} | Hints used: {hintsUsed}");
            Console.WriteLine();
            
            // Check if all words are hidden
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("Congratulations! You've mastered this scripture!");
                Console.WriteLine($"\nFinal Stats:");
                Console.WriteLine($"  • Rounds completed: {roundsCompleted}");
                Console.WriteLine($"  • Hints used: {hintsUsed}");
                Console.WriteLine($"  • Total words: {totalWords}");
                break;
            }
            
            // Show options
            Console.WriteLine("Options:");
            Console.WriteLine("  Press Enter - Hide more words");
            Console.WriteLine("  Type 'hint' - Reveal one hidden word");
            Console.WriteLine("  Type 'quit' - Exit program");
            Console.Write("\nYour choice: ");
            
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                Console.WriteLine("\nKeep practicing!");
                break;
            }
            else if (input.ToLower() == "hint")
            {
                if (scripture.RevealOneWord())
                {
                    hintsUsed++;
                    Console.WriteLine("\nA word has been revealed to help you!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nNo hidden words to reveal yet!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                continue;
            }
            
            // Hide random words with selected difficulty
            scripture.HideRandomWords(wordsToHidePerRound);
            roundsCompleted++;
        }
        
        Console.WriteLine("\nThank you for using Scripture Memorizer!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    static int GetDifficultyLevel()
    {
        Console.WriteLine("Select Difficulty Level:");
        Console.WriteLine("1. Easy (Hide 1 word at a time)");
        Console.WriteLine("2. Medium (Hide 3 words at a time)");
        Console.WriteLine("3. Hard (Hide 5 words at a time)");
        Console.Write("Enter choice (1-3): ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                Console.WriteLine("\nEasy mode selected. One word at a time.\n");
                System.Threading.Thread.Sleep(1000);
                return 1;
            case "3":
                Console.WriteLine("\nHard mode selected. Five words at a time!\n");
                System.Threading.Thread.Sleep(1000);
                return 5;
            default:
                Console.WriteLine("\nMedium mode selected. Three words at a time.\n");
                System.Threading.Thread.Sleep(1000);
                return 3;
        }
    }
}