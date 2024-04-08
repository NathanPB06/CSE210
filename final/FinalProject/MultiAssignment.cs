public class MultiAssignment : Assignment {
    private int _target;
    private int _completed;
    public MultiAssignment(string name, string description, int target) : base(name, description) {
        _target = target;
        _completed = 0;
    }
    public MultiAssignment(string name, string description, int target, int completed) : base(name, description) {
        _target = target;
        _completed = completed;
    }
    public MultiAssignment(string name, string description, int grade, int target, int completed) : base(name, description, grade){
        _target = target;
        _completed = completed;
    }
    public override void Complete(int grade){
        _completed += 1;
        Console.WriteLine($"Good job! You completed the assignment!");
        SetGrade(grade);
    }
    public override void SetGrade(int grade)
    {
        _grade = (_grade + grade)/_completed;
    }
    public override string GetStoredString() {
        return $"MultiAssignment:{_name},{_description},{_grade},{_completed},{_target}";
    }
    public override string GetDisplayString() {
        return $"{_name} ({_description}) Total grade: {_grade}% Completed:{_completed}/{_target}";
    }
    public override bool IsComplete()
    {
        if (_completed >= _target) {
            return true;
        }
        else {
            return false;
        }
    }
}