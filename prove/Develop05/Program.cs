using System;

class Program
{
    static void Main(string[] args)
    {
        //Added additional functionality in ChecklistGoals.cs to tell user how many bonus points they earned on line 14, as well as functionality to tell the user how many more times are needed to achieve the bonus on line 19.
        //Added additional functionality in EternalGoal.cs to tell used number of times they have completed the goal.

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
        
    }
}