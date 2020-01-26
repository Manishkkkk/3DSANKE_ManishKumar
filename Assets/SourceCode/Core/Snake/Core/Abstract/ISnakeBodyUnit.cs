using Zenject;
namespace Core.Snake
{
    public interface ISnakeBodyUnit
    {
        void InjectDependency(SignalBus signalBus);
        void OnSnakeBodyHit();
    }
}
