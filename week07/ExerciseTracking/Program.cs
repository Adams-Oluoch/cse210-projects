using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create at least one activity of each type
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),      // 3 miles in 30 minutes
            new Cycling("03 Nov 2022", 45, 15.0),     // 15 mph for 45 minutes
            new Swimming("03 Nov 2022", 40, 30)       // 30 laps in 40 minutes
        };

        Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    EXERCISE TRACKING PROGRAM                   ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        // Iterate through the list and call GetSummary on each
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"  • {activity.GetSummary()}");
            Console.WriteLine();
        }

        Console.WriteLine("═══════════════════════════════════════════════════════════════════");
    }
}