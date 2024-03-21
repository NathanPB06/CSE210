public class Listing : Activity {
    private List<string> _prompts = new List<string>();
    public Listing() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {
        _prompts.Add("When have you helped others recently?");
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("Who do you look up to?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("What scriptures have stuck out to you?");
    }
    public string GetRandomPrompt() {
        Random rnd = new Random();
        return _prompts[rnd.Next(0, _prompts.Count())];
    }
    public List<string> GetListFromUser() {
        List<string> userList = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime newTime = startTime.AddSeconds(GetDur());
        Console.WriteLine();
        while (startTime < newTime) {
            Console.Write(">");
            userList.Add(Console.ReadLine());
            startTime = DateTime.Now;
        }
        return userList;
    }
    public void Run() {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {userList.Count()} items!");
        DisplayEndingMessage();
    }
}