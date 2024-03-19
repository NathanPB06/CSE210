public class Assignment {
    public Assignment(string name, string topic) {
        _studentName = name;
        _topic = topic;
    }
    private string _studentName;
    private string _topic;
    public string GetSummary() {
        return _studentName + " - " + _topic;
    }
    public string GetStudentName() {
        return _studentName;
    }
}