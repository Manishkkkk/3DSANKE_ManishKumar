using Zenject;

public interface ISnakeBodyUnit
{
    void InjectDependency(SignalBus signalBus);
    void OnSnakeBodyHit();
}
