using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Runtime;

public class WeekManager {
    private List<Day> _days = new List<Day>();
    public void Start() {
        string choice = "0";
        Console.Clear();
        while (choice != "6") {
            ShowGrade();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create And Assign New Assignment");
            Console.WriteLine("  2. Show Week");
            Console.WriteLine("  3. Save Week");
            Console.WriteLine("  4. Load Week");
            Console.WriteLine("  5. Complete Assignment");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            if (choice == "1") {
                Console.Clear();
                CreateAssignment();
            }
            else if (choice == "2") {
                Console.Clear();
                ShowWeek();
            }
            else if (choice == "3") {
                Console.Clear();
                Save();
            }
            else if (choice == "4") {
                Console.Clear();
                Load();
            }
            else if (choice == "5") {
                Console.Clear();
                Complete();
            }
        }
        Console.WriteLine("Goodbye!");
    }
    private void ShowGrade() {
        int grade = 0;
        int num = _days.Count();
        foreach (Day day in _days) {
            grade += day.ComputeGrade();
        }
        if (num != 0) {
            Console.WriteLine($"Your grade for this week is {grade/num}%");
        }
        else {
            Console.WriteLine($"Your grade for this week is 0%");
        }
    }
    private void ShowWeek() {
        int i =1;
        foreach (Day day in _days) {
            List<Assignment> assignments = day.GetAssignments();
            Console.WriteLine($"Day {day.GetDay()}:");
            Console.WriteLine(" Assignments:");
            foreach (Assignment assignment in assignments) {
                if (assignment.IsComplete() == true){
                    Console.WriteLine($"        {i}.    [X] {assignment.GetDisplayString()}");
                }
                else {
                    Console.WriteLine($"        {i}.    [ ] {assignment.GetDisplayString()}");
                }
                i += 1;
            }
        }
    }
    private void CreateAssignment() {
        Console.WriteLine("The types of Assignments are:");
        Console.WriteLine("  1. Single Assignment");
        Console.WriteLine("  2. Multi Assignment (To be completed multiple times)");
        Console.Write("Which type of assignment would you like to create? ");
        string pick = Console.ReadLine();
        if (pick == "1") {
            Console.Write("What is the name of your assignment? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of the assignment? ");
            string description = Console.ReadLine();
            Console.Write("What day would you like to assign this to? (1-7)");
            int pickDay = Int32.Parse(Console.ReadLine());
            SingleAssignment newAssignment = new SingleAssignment(name, description);
            List<int> k = new List<int>();
            foreach (Day day in _days) {
                k.Add(day.GetDay());
            }
            if (k.Contains(pickDay) == false) {
                    Day newDay = new Day(pickDay);
                    newDay.AddAssignment(newAssignment);
                    _days.Add(newDay);
            }
            else {
                foreach (Day day in _days) {
                    if (day.GetDay() == pickDay) {
                        day.AddAssignment(newAssignment);
                    }
                }
            }

        }
        else if (pick == "2") {
            Console.Write("What is the name of your assignment? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of the assignment? ");
            string description = Console.ReadLine();
            Console.Write("What day would you like to assign this to? (1-7)");
            int pickDay = Int32.Parse(Console.ReadLine());
            Console.Write("How many times does this assignment need to be completed? ");
            int target = Int32.Parse(Console.ReadLine());
            MultiAssignment newAssignment = new MultiAssignment(name, description, target);
            List<int> k = new List<int>();
            foreach (Day day in _days) {
                k.Add(day.GetDay());
            }
            if (k.Contains(pickDay) == false) {
                    Day newDay = new Day(pickDay);
                    newDay.AddAssignment(newAssignment);
                    _days.Add(newDay);
            }
            else {
                foreach (Day day in _days) {
                    if (day.GetDay() == pickDay) {
                        day.AddAssignment(newAssignment);
                    }
                }
            }
        }
        else {
            Console.WriteLine("Not an option.");
        }
    }
    private void Complete() {
        ShowWeek();
        int i = 1;
        Console.Write("Which assignment did you finish? ");
        int pick = Int32.Parse(Console.ReadLine());
        foreach (Day day in _days) {
            List<Assignment> assignments = day.GetAssignments();
            foreach (Assignment assignment in assignments) {                if (pick == i){
                    Console.Write("What grade did you get on this assignment? ");
                    int grade = Int32.Parse(Console.ReadLine());
                    assignment.Complete(grade);
                }
                i+=1;
            }
        }
    }
    private void Save() {
        Console.Write("What is the filename for the week file? ");
        string fileName = Console.ReadLine();
        //This has sometimes worked without needing the full path, but sometimes it requires the full path. Unsure why.
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            foreach (Day day in _days) {
                List<Assignment> assignments = day.GetAssignments();
                foreach (Assignment assignment in assignments) {
                outputFile.WriteLine(assignment.GetStoredString() + "," + day.GetDay());
                }
            }
        }
    }
    private void Load() {
        //Requires full path, again, unsure why.
        Console.Write("What is the filename for the week file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines) {
            string[] parts = line.Split(":");
            string type = parts[0];
            string data = parts[1];
            string[] dataPieces = data.Split(",");
            List<int> k = new List<int>();
            foreach (Day day in _days) {
                k.Add(day.GetDay());
            }
            if (type == "SingleAssignment") {
                SingleAssignment newAssignment = new SingleAssignment(dataPieces[0], dataPieces[1], bool.Parse(dataPieces[2]), Int32.Parse(dataPieces[3]));
                if (k.Contains(Int32.Parse(dataPieces[4])) == false) {
                    Day newDay = new Day(Int32.Parse(dataPieces[4]));
                    newDay.AddAssignment(newAssignment);
                    _days.Add(newDay);
                }
                else {
                    foreach (Day day in _days) {
                        if (day.GetDay() == Int32.Parse(dataPieces[4])) {
                            day.AddAssignment(newAssignment);
                        }
                    }
                }
            }
            else if (type == "MultiAssignment") {
                MultiAssignment newAssignment = new MultiAssignment(dataPieces[0], dataPieces[1], Int32.Parse(dataPieces[2]), Int32.Parse(dataPieces[4]), Int32.Parse(dataPieces[3]));
                if (k.Contains(Int32.Parse(dataPieces[5])) == false) {
                        Day newDay = new Day(Int32.Parse(dataPieces[5]));
                        newDay.AddAssignment(newAssignment);
                        _days.Add(newDay);
                }
                else {
                   foreach (Day day in _days) {
                        if (day.GetDay() == Int32.Parse(dataPieces[4])) {
                            day.AddAssignment(newAssignment);
                        }
                    } 
                }
            }            
        }       
    }
}