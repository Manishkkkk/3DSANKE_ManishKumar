using UnityEngine;

public class FoodSpawnController : MonoBehaviour
{
    FoodSpawnBehaviour FoodSpawnBehaviour;

    private void SpawnFood()
    {
        FoodSpawnBehaviour.SpawnRandomFoods();
    }
}