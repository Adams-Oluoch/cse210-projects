using System;

class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"⚠️ Warning: This will subtract {_points} points! ⚠️");
        Console.Write("Are you sure you want to record this negative habit? (y/n): ");
        string confirmation = Console.ReadLine().ToLower();
        
        if (confirmation == "y" || confirmation == "yes")
        {
            Console.WriteLine($"😢 -{_points} points for {_name}");
            return -_points;
        }
        else
        {
            Console.WriteLine("Good choice! Negative goal not recorded.");
            return 0;
        }
    }

    public override bool IsComplete() => false;

    public override string GetDetails()
    {
        return $"[!] {_name} ({_description}) -- Penalty: -{_points} pts";
    }

    public override string GetStringRepresentation()
    {
        return $"Negative|{_name}|{_description}|{_points}";
    }
}