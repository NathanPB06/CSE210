public class WritingAssignment : Assignment {
    public WritingAssignment(string title, string name, string topic) : base(name, topic) {
        _title = title;
    }
    private string _title;
    public string GetWritingInformation() {
        return _title + " by " + GetStudentName();
    }
}