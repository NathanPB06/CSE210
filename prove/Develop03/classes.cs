using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks.Dataflow;

public class Scripture {    
    //Vars
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    //Constructor
    public Scripture(Reference reference, string text) {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (string word in words) {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    //other functions
    public int WordCount() {
        return _words.Count();
    }
    public string GetDisplayText() {
        string text = "";
        foreach (Word word in _words) {
            if (word.IsHidden() == true) {
                text += "___ ";
            }
            else if (word.IsHidden() == false) {
                text += word.GetDisplayText() + " ";
            }
            
        }
        return text;
    }

    public void HideRandomWords(int hideRef) {
        while (_words[hideRef].IsHidden() == true) {
            hideRef += 1;
        }
        _words[hideRef].Hide();
    }
    public bool IsCompletelyHidden() {
        int i = 0;
        foreach (Word word in _words) {
            if (word.IsHidden() == false) {
                i += 1;
            }
            else {
                i += 0;
            }
        }
        if (i > 0) {
            return false;
        }
        else {
            return true;
        }
    }
}
public class Word {    
    //Vars
    private string _text;
    private bool _isHidden;

    //Constructor
    public Word(string text) {
        _text = text;
    }

    //other functions
    public void Hide() {
        _isHidden = true;
    }
    public void Show() {
        _isHidden = false;
    }
    public bool IsHidden() {
        return _isHidden;
    }
    public string GetDisplayText() {
        return _text;
    }
}
public class Reference {
    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string book, int chapter, int verse, int endverse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endverse;
    }
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

}