using Core.Food;

public struct OnFoodHitSignal
{
    public IFoodUnit foodUnit;
    public IFoodScore foodScore;

    public OnFoodHitSignal(IFoodUnit foodUnit, IFoodScore foodScore)
    {
        this.foodUnit = foodUnit;
        this.foodScore = foodScore;
    }
}

public struct OnScoreUpdateSignal
{
    public int score;

    public OnScoreUpdateSignal(int score)
    {
        this.score = score;
    }
}

public struct OnStreakUpdateSignal
{
    public int streakValue;

    public OnStreakUpdateSignal(int streakValue)
    {
        this.streakValue = streakValue;
    }
}
