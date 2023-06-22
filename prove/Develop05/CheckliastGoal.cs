class ChecklistGoal : Goal
{
    private int currentCount;
    private int targetCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
    }

    public override string DisplayProgress()
    {
        return "Goal: " + Name + " - " + Description + " (" + Points + " points) - Progress: " + currentCount + "/" + targetCount;
    }

    public override void RecordAccomplishment()
    {
        currentCount++;

        if (currentCount >= targetCount)
        {
            Points += bonusPoints;
            currentCount = 0;
        }
    }

    public override string ToFileString()
    {
        return "Checklist Goal:" + Name + "," + Description + "," + Points + "," + targetCount + "," + bonusPoints;
    }

    public override bool IsCompleted => currentCount >= targetCount && currentCount > 0;

}
