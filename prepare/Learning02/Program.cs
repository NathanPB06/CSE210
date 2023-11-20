using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2000;
        job1._endYear = 2024;
        job1.Display();
        Resume resume1 = new Resume();
        resume1._name = "Allison Rose";
        resume1._jobs = new List<Job>();
        resume1._jobs.Add(job1);
        resume1.Display();
    }
}