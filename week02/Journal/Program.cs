using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!\n");
        
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;
        
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nThank you for using the Journal Program. Goodbye!\n");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.\n");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }
    
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        Console.WriteLine();
        
        // Get random prompt
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        
        // Get user response
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        // Create and add entry
        Entry entry = new Entry();
        entry._prompt = prompt;
        entry._response = response;
        entry._date = DateTime.Now.ToString("yyyy-MM-dd");
        
        journal.AddEntry(entry);
        
        Console.WriteLine("\nEntry saved successfully!\n");
    }
    
    static void SaveJournal(Journal journal)
    {
        if (journal._entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to save. Write some entries first!\n");
            return;
        }
        
        Console.Write("\nEnter filename to save (e.g., journal.txt): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("\nInvalid filename.\n");
            return;
        }
        
        // Add .txt extension if not present
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in journal._entries)
                {
                    // Format: date|prompt|response
                    writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                }
            }
            Console.WriteLine($"\nJournal saved to {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving: {ex.Message}\n");
        }
    }
    
    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load (e.g., journal.txt): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("\nInvalid filename.\n");
            return;
        }
        
        // Add .txt extension if not present
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }
        
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\nFile '{filename}' not found.\n");
                return;
            }
            
            // Clear current journal
            journal._entries.Clear();
            
            // Read and load entries
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry();
                        entry._date = parts[0];
                        entry._prompt = parts[1];
                        entry._response = parts[2];
                        journal.AddEntry(entry);
                    }
                }
            }
            
            Console.WriteLine($"\nLoaded {journal._entries.Count} entries from {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading: {ex.Message}\n");
        }
    }
}