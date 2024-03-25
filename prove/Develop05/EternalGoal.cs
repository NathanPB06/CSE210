public class EternalGoal : Goal {
    private int _num;
    public EternalGoal(string name, string description, int points, int num) : base(name, description, points) {
        _num = num;
    }
    public EternalGoal(string name, string description, int points) : base(name, description, points) {
        _num = 0;
    }
    public override int RecordEvent()
    {
        _num += 1;
        Console.WriteLine($"Congratulations! You have earned {_points} points. You have completed this goal {_num} times, earning {_num * _points} points total.");
        return _points;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points},{_num}";
    }
    public override string GetDetailsString()
    {
        //functionality to tell number of times completed.
        return $"{_shortName} ({_description}) (Completed {_num} times.)";
    }
}