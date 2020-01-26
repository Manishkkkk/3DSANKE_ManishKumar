using System.Collections.Generic;
namespace Core.Food
{
    public interface IFoodSpawner
    {
        List<IFood> Food { get; }
        void SpawnRandomFoods();
    }
}
