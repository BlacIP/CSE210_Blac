abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract string DisplayProgress();
    public abstract void RecordAccomplishment();
    public abstract string ToFileString();
    public abstract bool IsCompleted { get; }


    public static Goal FromFileString(string fileString)
    
    {
        string[] data = fileString.Split(':');
        string goalType = data[0];
        string name = data[1];
        string description = data[2];
        int points = int.Parse(data[3]);

        switch (goalType)
        {
            case "Simple Goal":
                return new SimpleGoal(name, description, points);
            case "Eternal Goal":
                return new EternalGoal(name, description, points);
            case "Checklist Goal":
                int targetCount = int.Parse(data[4]);
                int bonusPoints = int.Parse(data[5]);
                return new ChecklistGoal(name, description, points, targetCount, bonusPoints);
            default:
                return null;
        }
    }
}
