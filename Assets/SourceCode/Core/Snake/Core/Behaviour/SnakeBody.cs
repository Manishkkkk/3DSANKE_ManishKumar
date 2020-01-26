using UnityEngine;
using Zenject;
namespace Core.Snake
{
    public class SnakeBody : MonoBehaviour, ISnakeBodyUnit
    {
        private SignalBus signalBus;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Snake")
            {
                OnSnakeBodyHit();
            }
        }

        public void InjectDependency(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void OnSnakeBodyHit()
        {
            signalBus.Fire<OnSnakeBodyHitSignal>();
        }
    }
}
