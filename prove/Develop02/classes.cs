using System.Globalization;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;
using System.IO;
using System.Configuration.Assemblies;
using System.Runtime.InteropServices;
public class Entry {
    public string _date;
    public  string _response;
    public string _prompt;
    public void Display() {
        Console.WriteLine($"Date: {_date} Prompt: {_prompt} Response: {_response}");
    }
}
public class Journal {
    List<string> entries = new List<string>();
    public void AddEntry(string newEntry) {
        entries.Add(newEntry);
    }
    public void DisplayAll() {
        foreach (string entry in entries) {
            Console.WriteLine(entry);
        }
    }
    public void SaveToFile(string fileName) {
        using (StreamWriter file = new StreamWriter(fileName)) {
            foreach (string entry in entries) {
                file.WriteLine($"{entry} |");
            }
        }
    }
    public void LoadFromFile(string FileName) {
        List<string> apple = new List<string>();
        string[] lines = System.IO.File.ReadAllLines(FileName);
        foreach (string line in lines) {
            string[] parts = line.Split("|");
            foreach (string part in parts) {
                Console.WriteLine(part);
            }
        }
    }
}
public class promptGenerator {
    public Random rnd = new Random();
    public List<string> _prompts = new List<string>();
    public string generatePrompt(int num) {
        return _prompts[num];
    }
}