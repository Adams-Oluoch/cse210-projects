using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
          )
    { }

    public override void Run()
    {
        StartActivity();

        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.Write("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine();

            if (elapsed + 4 < _duration)
            {
                Console.Write("Breathe out...");
                ShowCountdown(6);
                Console.WriteLine();
            }

            elapsed += 10;
        }

        EndActivity();
    }
}