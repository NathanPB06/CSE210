public class MathAssignment : Assignment {
    public MathAssignment(string problems, string textbookSection, string name, string topic) : base(name, topic) {
        _textbookSection = textbookSection;
        _problems = problems;
    }
    private string _textbookSection;
    private string _problems;  
    public string GetHomeworkList() {
        return "Section " + _textbookSection + " Problems " + _problems;
    }

}