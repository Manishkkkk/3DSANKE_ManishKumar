using System;
using UnityEngine;
using Zenject;
namespace Core.Food
{
    public class FoodSpawnController : MonoBehaviour, IInitializable, IDisposable
    {
        private FoodSpawnBehaviour FoodSpawnBehaviour;

        private SignalBus signalBus;

        [SerializeField] private Settings settings;

        [Inject]
        private void Contruct(SignalBus signalBus, FoodSpawnBehaviour FoodSpawnBehaviour)
        {
            this.signalBus = signalBus;
            this.FoodSpawnBehaviour = FoodSpawnBehaviour;
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<OnFoodHitSignal>(SpawnFood);
        }

        public void Initialize()
        {
            signalBus.Subscribe<OnFoodHitSignal>(SpawnFood);

            SpawnIntialFood();
        }

        private void SpawnIntialFood()
        {
            for (int i = 0; i < settings.intialFoodCount; i++)
            {
                SpawnFood();
            }
        }

        private void SpawnFood()
        {
            FoodSpawnBehaviour.SpawnRandomFoods();
        }

        [System.Serializable]
        public class Settings
        {
            public int intialFoodCount;
        }
    }
}