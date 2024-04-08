/*Week Assignment Planner

Conceptually it is fairly similar to week 5's goal program, however I find that this will likely be more complex and helpful to me in a real scenario.

WeekManager Handles all menuing, the logic for creating assignments and assigning assignments to days, and displaying past weeks assignments. 
It interacts with the public functions of most of the classes.

WeekManager
    List<Day> _days

    Run() : void    Handles menuing
    ShowGrade() : void  Computes and displays total grade for all assignments
    ShowWeek() : void   Iterates through each assignment per day and displays
    CreateAssignment() : void   Prompts the user about an assignment, creates new assignment and assigns to day
    Complete() : void   Does necessary actions to mark assignment as complete
    Save() : void   Saves assignments to file
    Load() : void   Loads assignments from file

Assignment
    string _name
    string _description
    int _grade

    Assignment(name, description)
    Assignment(name, description, grade)

    GetGrade() : int    Gets grade
    virtual SetGrade() : void   Sets grade
    abstract Complete(grade : int) : void  Does necessary actions per class to mark assignment as complete
    abstract GetStoredString() : string     Converts information to string to be stored in file
    abstract GetDisplayString() : string    Converts information to string to be displayed
    abstract IsComplete() : bool    Checks if assignment is complete

SingleAssignment : Assignment
    bool _isComplete

    SingleAssignment(name, description)
    SingleAssignment(name, description, isComplete, grade)

    override Complete(grade : int) : void
    override GetStoredString() : string
    override GetDisplayString() : string
    override IsComplete() : bool

MultiAssignment : Assignment
    int _target
    int _completed

    MultiAssignment(name, description, target)
    MultiAssignment(name, description, target, completed)
    MultiAssignment(name, description, grade, target, completed)

    override Complete(grade : int) : void
    override GetStoredString() : string
    override GetDisplayString() : string
    override IsComplete() : bool   
    override SetGrade(grade : int) : void

Day 
    int _day
    List<Assignment> _assignments

    Day(day)

    AddAssignment(assignment : Assignment) : void   Add assignment to list of assignments for the day
    GetAssignments() : List<Assignment>     Getter for assignments
    ComputeGrade() : int    Compute grade for the day
    GetDay() : int  Getter for day




*/

