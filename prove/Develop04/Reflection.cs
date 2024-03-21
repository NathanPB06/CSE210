public class Reflection : Activity {
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    public Reflection() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") {
        _prompts.Add("Think of a time when you did something difficult.");
        _prompts.Add("Think of a time when you feel that you improved yourself.");
        _prompts.Add("think of a time when you did something truly selfless.");
        _prompts.Add("Think of a time when you chose the right thing even though it was hard.");

        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }
    public string GetRandomPrompt() {
        Random rnd = new Random();
        return _prompts[rnd.Next(0, _prompts.Count())];
    }
    public string GetRandomQuestion() {
        Random rnd = new Random();
        return _questions[rnd.Next(0, _questions.Count())];
    }
    public void DisplayPrompt() {
        Console.Write($"{GetRandomPrompt()}");
    }
    public void DisplayQuestion() {
        Console.Write($"{GetRandomQuestion()}  ");
    }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.Write($" --- ");
        DisplayPrompt();
        Console.Write(" ---");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime newTime = startTime.AddSeconds(GetDur());
        while (startTime < newTime) {
            DisplayQuestion();
            ShowSpinner(10);
            Console.WriteLine();
            startTime = DateTime.Now;
        }
        DisplayEndingMessage();
    }

}