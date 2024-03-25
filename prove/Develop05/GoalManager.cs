using System.IO.Enumeration;
using System.Runtime;
using Microsoft.VisualBasic;

public class GoalManager {
    public GoalManager() {
        _goals = new List<Goal>();
        _score = 0;
    }
    private List<Goal> _goals;
    private int _score;
    public void Start() {
        string choice = "0";
        while (choice != "6") {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            if (choice == "1") {
                Console.Clear();
                CreateGoal();            
            }
            else if (choice == "2") {
                Console.Clear();
                ListGoals();                
            }
            else if (choice == "3") {
                Console.Clear();
                SaveGoals();
            }
            else if (choice == "4") {
                Console.Clear();
                LoadGoals();
            }
            else if (choice == "5") {
                Console.Clear();
                RecordEvent();
            }
        }
        Console.WriteLine("Goodbye!");
    }
    private void DisplayPlayerInfo() {
        Console.WriteLine($"You have {_score} points.");
    }
    private void ListGoals() {
        int i = 1;
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals) {
            if (goal.IsComplete() == true) {
                Console.WriteLine($"{i}. [X] {goal.GetDetailsString()}");
            }
            else {
                Console.WriteLine($"{i}. [ ] {goal.GetDetailsString()}");
            }
            i += 1;
        }
    }
    private void CreateGoal() {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string pick = Console.ReadLine();
        if (pick == "1" || pick == "2") {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of the goal? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? " );
            int points = Int32.Parse(Console.ReadLine());
            if (pick == "1"){
                _goals.Add(new SimpleGoal(name, description, points)); 
            }
            else {
                _goals.Add(new EternalGoal(name, description, points)); 
            }   
        }
        else if (pick == "3") {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of the goal? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal?" );
            int points = Int32.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished to earn a bonus? ");
            int target = Int32.Parse(Console.ReadLine());
            Console.Write($"What is the bonus for accomplishing the goal {target} times? ");
            int bonus = Int32.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else {
            Console.WriteLine("Not an option.");
        }
    }
    private void RecordEvent() {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int pick = Int32.Parse(Console.ReadLine());
        if (_goals[pick-1].IsComplete() == false) {
            _score += _goals[pick-1].RecordEvent();            
        }
        else {
            Console.WriteLine("You have already completed this goal.");
        }
    }
    private void SaveGoals() {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        //This has sometimes worked without needing the full path, but sometimes it requires the full path. Unsure why.
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals) {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    private void LoadGoals() {
        //Requires full path, again, unsure why.
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines) {
            _score = Int32.Parse(lines[0]);
            if (lines[0] != line) {
                string[] parts = line.Split(":");
                string type = parts[0];
                string data = parts[1];
                string[] dataPieces = data.Split(",");
                if (type == "SimpleGoal") {
                    _goals.Add(new SimpleGoal(dataPieces[0], dataPieces[1], Int32.Parse(dataPieces[2]), bool.Parse(dataPieces[3])));
                }
                else if (type == "ChecklistGoal") {
                    _goals.Add(new ChecklistGoal(dataPieces[0], dataPieces[1], Int32.Parse(dataPieces[2]), Int32.Parse(dataPieces[4]), Int32.Parse(dataPieces[3]), Int32.Parse(dataPieces[5])));
                }
                else if (type == "EternalGoal") {
                    _goals.Add(new EternalGoal(dataPieces[0], dataPieces[1], Int32.Parse(dataPieces[2]), Int32.Parse(dataPieces[3])));
                }
            }
        }       
    }
}