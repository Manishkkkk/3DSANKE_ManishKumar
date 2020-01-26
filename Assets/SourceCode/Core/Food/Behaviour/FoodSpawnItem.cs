using UnityEngine;
using Zenject;
namespace Core.Food
{
    public class FoodSpawnItem : MonoBehaviour, IFoodSpawnUnit
    {
        private SignalBus signalBus;
        public IFoodUnit FoodUnit { get; private set; }

        public IFoodScore FoodScore { get; private set; }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Snake")
            {
                DisptachOnFoodHit();
            }
        }



        public void DisptachOnFoodHit()
        {
            signalBus.Fire(new OnFoodHitSignal(FoodUnit, FoodScore));
            Destroy(this.gameObject);
        }

        public void InjectDependency(SignalBus signalBus, IFoodUnit foodUnit, IFoodScore foodScore)
        {
            this.signalBus = signalBus;
            this.FoodUnit = foodUnit;
            this.FoodScore = foodScore;
        }
    }
}