using System;
using System.Globalization;
using System.IO.Enumeration;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {        
        /*setting classes for later*/
        Journal journal = new Journal();
        Random rnd = new Random();
        promptGenerator gen = new promptGenerator();


        
        //setting prompts, not sure if I should read these from a file or not so I just put them here.
        List<string> lst = new List<string>();
        lst.Add("What did you eat for breakfast?");
        lst.Add("What assignments did you do today?");
        lst.Add("Did you finish any goals today?");
        lst.Add("Did you have any strong feelings today?");
        lst.Add("Did you meet anyone new today?");
        lst.Add("What was your favorite part of the day?");
        gen._prompts = lst;
        int pick = 10;

        //if-then statements
        while (pick != 5) {

        //select choice
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("Which woould you like to do?");
        pick = int.Parse(Console.ReadLine());   

        if (pick == 1) {
            Entry entry = new Entry();
            int num = rnd.Next(0, lst.Count());
            entry._prompt = gen.generatePrompt(num);
            Console.WriteLine(entry._prompt);
            entry._response = Console.ReadLine();
            
            //set date
            DateTime currentDate = DateTime.Now;
            string dateText = currentDate.ToShortDateString();
            entry._date = dateText;

            journal.AddEntry($"Date: {entry._date} Prompt: {entry._prompt} Response: {entry._response}");
        }
        else if (pick == 2){
            journal.DisplayAll();
        }
        else if (pick == 3) {
            Console.WriteLine("What is the filename?");
            string filename = Console.ReadLine();
            journal.LoadFromFile(filename);
        }
        else if (pick == 4) {
            //requires full path, not sure why
            Console.WriteLine("What is the file name?");
            string fileName = Console.ReadLine();
            journal.SaveToFile(fileName);
        }
        }

    }
}