public struct OnFoodHitSignal
{
    public IFoodUnit foodUnit;

    public OnFoodHitSignal(IFoodUnit foodUnit)
    {
        this.foodUnit = foodUnit;
    }
}
