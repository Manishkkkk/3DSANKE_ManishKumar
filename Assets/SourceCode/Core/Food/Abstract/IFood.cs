using UnityEngine;

namespace Core.Food
{
    public interface IFoodScore
    {
        int Score { get; }
    }
    public interface IFood : IFoodUnit, ISpawnable, ISpawnArea, IFoodScore
    {
        GameObject FoodPrefab { get; }
        float Yoffeset { get; }

        //This is a food class takes the gameobject in the settings part
        //Generate the food class and use factory to create theese objects
    }
}
