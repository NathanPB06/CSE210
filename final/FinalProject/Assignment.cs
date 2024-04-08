public abstract class Assignment {
    protected string _name;
    protected string _description;
    protected int _grade;
    public Assignment(string name, string description){
        _name = name;
        _description = description;
        _grade = 0;
    }
    public Assignment(string name, string description, int grade){
        _name = name;
        _description = description;
        _grade = grade;        
    }
    public int GetGrade() {
        return _grade;
    }
    public virtual void SetGrade(int grade) {
        _grade = grade;
    }
    public abstract void Complete(int grade);
    public abstract string GetStoredString();
    public abstract string GetDisplayString();
    public abstract bool IsComplete();
}