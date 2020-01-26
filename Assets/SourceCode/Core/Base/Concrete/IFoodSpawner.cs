using System.Collections.Generic;

public interface IFoodSpawner
{
    List<IFood> Food { get; }
    void SpawnRandomFoods();
}
