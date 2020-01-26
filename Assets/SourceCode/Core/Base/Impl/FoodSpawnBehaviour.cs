using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FoodSpawnBehaviour : IFoodSpawner, ITickable
{
    public FoodSpawnBehaviour(List<IFood> food)
    {
        Food = food;
    }

    public List<IFood> Food { get; set; }

    public void SpawnRandomFoods()
    {
        int index = UnityEngine.Random.Range(0, Food.Count);
        Food[index].Spawn();
    }

    public void Tick()
    {
        if(Input.GetKey(KeyCode.O))
        {
            SpawnRandomFoods();
        }
    }
}



