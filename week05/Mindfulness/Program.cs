using System;
using System.Threading;

/*
 * EXCEEDING REQUIREMENTS:
 * 
 * This program includes the following creative elements beyond the core requirements:
 * 
 * 1. ACTIVITY TRACKING - The program tracks how many mindfulness activities the user 
 *    completes during a single session and displays the total when the user quits.
 *    This provides positive reinforcement and encourages continued use.
 * 
 * 2. COMPREHENSIVE QUESTIONS - The Reflection activity includes 9 different questions
 *    (compared to the minimum requirement of a few), providing deeper reflection 
 *    opportunities without repeating questions as often.
 * 
 * 3. EXTENDED PROMPTS - Both Reflection and Listing activities include more prompts
 *    than required, giving users variety across multiple sessions.
 * 
 * 4. BETTER BREATHING TIMING - The breathing activity properly checks elapsed time
 *    before displaying "Breathe out..." to ensure it doesn't exceed the session duration.
 * 
 * 5. PAUSE AFTER PROMPTS - The Reflection activity gives users time to think before
 *    moving to the next question, with a visual spinner indicating waiting time.
 */

class Program
{
    static void Main()
    {
        int completedActivities = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Activity currentActivity = null;

            switch (choice)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    break;
                case "2":
                    currentActivity = new ReflectionActivity();
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine();
                    if (completedActivities > 0)
                    {
                        Console.WriteLine($"✨ You completed {completedActivities} mindfulness activities this session! ✨");
                        Console.WriteLine("Great job taking time for yourself!");
                    }
                    else
                    {
                        Console.WriteLine("Thank you for visiting. Come back when you need to relax!");
                    }
                    Thread.Sleep(3000);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    continue;
            }

            if (currentActivity != null)
            {
                currentActivity.Run();
                completedActivities++;
            }
        }
    }
}