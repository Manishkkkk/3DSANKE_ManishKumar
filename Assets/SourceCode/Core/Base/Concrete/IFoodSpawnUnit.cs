using Zenject;

public interface IFoodSpawnUnit 
{
    IFoodUnit FoodUnit { get; }

    IFoodScore FoodScore { get; }
    void InjectDependency(SignalBus signalBus, IFoodUnit foodUnit, IFoodScore foodScore);
    void DisptachOnFoodHit();
}
