class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override string DisplayProgress()
    {
        return "Goal: " + Name + " - " + Description + " (" + Points + " points)";
    }

    public override void RecordAccomplishment()
    {
        // Eternal goals don't require any specific action to record an accomplishment
    }

    public override string ToFileString()
    {
        return "Eternal Goal:" + Name + "," + Description + "," + Points;
    }

    public override bool IsCompleted
    {
        get { return false; }
    }
}
