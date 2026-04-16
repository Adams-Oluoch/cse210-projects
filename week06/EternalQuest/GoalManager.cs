using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;
        while (choice != 7)
        {
            DisplayLevel();
            Console.WriteLine($"\n✨ You have {_score} points ✨");
            Console.WriteLine("\n═══════════════════════════════");
            Console.WriteLine("        ETERNAL QUEST MENU");
            Console.WriteLine("═══════════════════════════════");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Progress Summary");
            Console.WriteLine("7. Quit");
            Console.WriteLine("═══════════════════════════════");
            Console.Write("\nSelect an option: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: ShowProgress(); break;
                case 7: 
                    Console.WriteLine("Thanks for playing! Keep working on your Eternal Quest! 🎮");
                    break;
            }
        }
    }

    private void DisplayLevel()
    {
        int level = GetLevel();
        string[] levelNames = { "Novice", "Apprentice", "Journeyman", "Expert", "Master", "Grand Master", "Eternal Champion" };
        int levelIndex = Math.Min(level / 1000, levelNames.Length - 1);
        string levelName = levelNames[levelIndex];
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n🏆 LEVEL {level} - {levelName} 🏆");
        Console.ResetColor();
    }

    private int GetLevel()
    {
        return _score / 1000;
    }

    private void CheckLevelUp(int oldLevel, int newLevel)
    {
        if (newLevel > oldLevel)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🎉🎉🎉 LEVEL UP! You reached Level {newLevel}! 🎉🎉🎉");
            Console.WriteLine("🌟 Keep up the great work on your Eternal Quest! 🌟");
            Console.ResetColor();
            
            // Celebration animation
            for (int i = 0; i < 3; i++)
            {
                Console.Write("✨");
                System.Threading.Thread.Sleep(200);
            }
            Console.WriteLine();
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("╔═══════════════════════════════╗");
        Console.WriteLine("║      SELECT GOAL TYPE         ║");
        Console.WriteLine("╠═══════════════════════════════╣");
        Console.WriteLine("║ 1. Simple Goal (one-time)     ║");
        Console.WriteLine("║ 2. Eternal Goal (repeatable)  ║");
        Console.WriteLine("║ 3. Checklist Goal (multi-step)║");
        Console.WriteLine("║ 4. Negative Goal (penalty)    ║");
        Console.WriteLine("╚═══════════════════════════════╝");
        Console.Write("\nChoice: ");
        
        int type = int.Parse(Console.ReadLine());

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points (positive for most goals, negative will be handled automatically): ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine($"✅ Simple goal '{name}' created!");
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine($"♾️ Eternal goal '{name}' created!");
        }
        else if (type == 3)
        {
            Console.Write("Number of times needed to complete: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points for completing all steps: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine($"📋 Checklist goal '{name}' created! (Need {target} completions)");
        }
        else if (type == 4)
        {
            _goals.Add(new NegativeGoal(name, description, points));
            Console.WriteLine($"⚠️ Negative goal '{name}' created! (Penalty goal)");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("📭 No goals yet. Create some goals to get started!");
            return;
        }

        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    YOUR GOALS                        ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"║ {i + 1}. {_goals[i].GetDetails()}");
        }
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create some goals first!");
            return;
        }

        ListGoals();
        Console.Write("\nWhich goal did you accomplish? (Enter number): ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];
        
        // Prevent recording completed simple goals
        if (goal.IsComplete() && goal is SimpleGoal)
        {
            Console.WriteLine($"❌ '{goal.GetName()}' is already completed! You cannot earn more points from it.");
            return;
        }

        int oldLevel = GetLevel();
        int earned = goal.RecordEvent();
        
        if (earned != 0)
        {
            _score += earned;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✅ You earned +{earned} points for '{goal.GetName()}'!");
            Console.ResetColor();
            
            int newLevel = GetLevel();
            CheckLevelUp(oldLevel, newLevel);
        }
        else if (earned == 0 && goal is SimpleGoal)
        {
            Console.WriteLine($"❌ '{goal.GetName()}' is already completed!");
        }
        else if (earned == 0 && goal is ChecklistGoal && goal.IsComplete())
        {
            Console.WriteLine($"❌ '{goal.GetName()}' is already fully completed!");
        }
    }

    private void ShowProgress()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to show progress for.");
            return;
        }

        int completedGoals = _goals.Count(g => g.IsComplete());
        int totalGoals = _goals.Count;
        double percentage = (double)completedGoals / totalGoals * 100;
        
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  PROGRESS SUMMARY                    ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════╣");
        Console.WriteLine($"║ Total Goals: {totalGoals,-47}║");
        Console.WriteLine($"║ Completed: {completedGoals,-50}║");
        Console.WriteLine($"║ Completion Rate: {percentage:F1}%-{45 - percentage.ToString("F1").Length}║");
        Console.WriteLine($"║ Current Score: {_score,-46}║");
        Console.WriteLine($"║ Current Level: {GetLevel(),-46}║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
        
        // Show checklist goals progress
        var checklistGoals = _goals.OfType<ChecklistGoal>().ToList();
        if (checklistGoals.Any())
        {
            Console.WriteLine("\n📋 Checklist Goal Details:");
            foreach (var goal in checklistGoals)
            {
                Console.WriteLine($"   • {goal.GetDetails()}");
            }
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_goals.Count);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"💾 Goals saved successfully! ({_goals.Count} goals)");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No save file found. Starting fresh!");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        int goalCount = int.Parse(lines[1]);

        for (int i = 2; i < 2 + goalCount && i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "Simple")
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));

            else if (parts[0] == "Eternal")
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));

            else if (parts[0] == "Negative")
                _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));

            else if (parts[0] == "Checklist")
                _goals.Add(new ChecklistGoal(parts[1], parts[2],
                    int.Parse(parts[3]),   // points
                    int.Parse(parts[5]),   // target
                    int.Parse(parts[4]),   // bonus
                    int.Parse(parts[6]))); // completed
        }
        
        Console.WriteLine($"📂 Goals loaded successfully! ({_goals.Count} goals, {_score} points)");
    }
}