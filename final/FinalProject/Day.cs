using System.Globalization;

public class Day {
    private int _day;
    private List<Assignment> _assignments = new List<Assignment>();

    public Day(int day){
        _day = day;
    }

    public void AddAssignment(Assignment assignment) {
        _assignments.Add(assignment);
    }
    public List<Assignment> GetAssignments() {
        return _assignments;
    }
    public int ComputeGrade() {
        int grade = 0;
        int num = _assignments.Count();
        foreach (Assignment assignment in _assignments) {
            grade += assignment.GetGrade();
        }
        return grade/num;
    }
    public int GetDay() {
        return _day;
    }
}