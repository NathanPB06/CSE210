public class SingleAssignment : Assignment {
    private bool _isComplete;
    public SingleAssignment(string name, string description) : base(name, description) {
        _isComplete = false;
    }
    public SingleAssignment(string name, string description, bool isComplete, int grade) : base(name, description, grade) {
        _isComplete = isComplete;
    }
    public override void Complete(int grade)
    {
        _isComplete = true;
        SetGrade(grade);
        Console.WriteLine("Congratulations! You completed the assignment!");
    }
    public override string GetStoredString() {
        return $"SingleAssignment:{_name},{_description},{_isComplete},{_grade}";
    }
    public override string GetDisplayString() {
        return $"{_name} ({_description}) Grade: {_grade}%";
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
}