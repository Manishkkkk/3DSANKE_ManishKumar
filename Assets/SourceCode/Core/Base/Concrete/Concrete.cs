using System.Collections.Generic;
using UnityEngine;
using Zenject;


public interface IFoodUnit
{
    int TypeID { get; }
}

public interface ISpawnable
{
    GameObject Spawn();
}

public interface ISpawnArea
{
    Vector3 Center { get; }
    Vector3 Size { get; }
}
public interface IFood: IFoodUnit, ISpawnable, ISpawnArea
{
    GameObject FoodPrefab { get; }
    float Yoffeset { get; }
 
    //This is a food class takes the gameobject in the settings part
    //Generate the food class and use factory to create theese objects
}

public interface IFoodSpawner
{
    List<IFood> Food { get; }
    void SpawnRandomFoods();
}

public interface IFoodSpawnUnit 
{
    IFoodUnit FoodUnit { get; }

    void InjectDependency(SignalBus signalBus, IFoodUnit foodUnit);

    void DisptachOnFoodHit();
}
