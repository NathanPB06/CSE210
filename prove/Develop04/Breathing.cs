using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;

public class Breathing : Activity{
    public Breathing() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") {
    }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine("How long would you like the breathing in time to be?");
        int In = Int32.Parse(Console.ReadLine());
        Console.WriteLine("How long would you like the breathing out time to be?");
        int Out = Int32.Parse(Console.ReadLine());
        Console.Clear();
        //I'm aware this part could be placed in the Activity class, however in order to ask the user about their breathing preference in the right order it has to be here.
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime newTime = startTime.AddSeconds(GetDur());
        while (startTime < newTime) {
            Console.WriteLine($"Breathe in...");
            ShowCountDown(In);
            Console.WriteLine("Breathe out...");
            ShowCountDown(Out);
            Console.WriteLine();
            startTime = DateTime.Now;
        }
        DisplayEndingMessage();
    }
}