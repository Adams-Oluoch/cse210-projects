// EXCEEDING REQUIREMENTS:
// 1. Added NegativeGoal type that subtracts points for bad habits (risk/reward mechanics)
// 2. Added leveling system - player gains levels every 1000 points
// 3. Added bonus celebration messages when checklist goals are completed
// 4. Added progress summary showing completion percentage
// 5. Added animated celebration effect when reaching a new level
// 6. Added "Are you sure?" confirmation for negative goals

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}