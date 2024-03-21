using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.Principal;

public class Activity {
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description) {
        _name = name;
        _description = description;
    }
    public int GetDur() {
        return _duration;
    }
    public void DisplayStartingMessage() {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like your session?");
        _duration = Int32.Parse(Console.ReadLine());
        Console.Clear();
    }
    public void DisplayEndingMessage() {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }
    public void ShowSpinner(int seconds) {
        DateTime startTime = DateTime.Now;
        DateTime newTime = startTime.AddSeconds(seconds);
        while (startTime < newTime) {
            startTime = DateTime.Now;
            Console.Write(">");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("<");
            Thread.Sleep(500);
            Console.Write("\b \b");

        }
    }
    public void ShowCountDown(int seconds) {
        DateTime startTime = DateTime.Now;
        DateTime newTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (startTime <= newTime) {
            startTime = DateTime.Now;
            Console.Write(seconds - i);
            i += 1;
            Thread.Sleep(999);
            Console.Write("\b \b");
        }
    }
}