using UnityEngine;
using Zenject;


public class RedFood : IFood
{
    public GameObject FoodPrefab { get; private set; }

    public float Yoffeset { get; private set; }

    public int TypeID { get; private set; }

    public Vector3 Center { get; private set; }

    public Vector3 Size { get; private set; }

    public int Score { get; private set; }

    private SignalBus signalBus;

    public RedFood(SignalBus signalBus, Settings settings)
    {
        this.signalBus = signalBus;
        FoodPrefab = settings.foodPrefab;
        Yoffeset = settings.yOffset;
        TypeID = settings.typeId;
        Center = settings.center;
        Size = settings.size;
        Score = settings.score;
    }

    public GameObject Spawn()
    {
        Vector3 pos = Center + new Vector3(UnityEngine.Random.Range(-Size.x / 2, Size.x / 2), Yoffeset, UnityEngine.Random.Range(-Size.x / 2, Size.x / 2));
        var go = GameObject.Instantiate(FoodPrefab, pos, Quaternion.identity);
        var component = go.GetComponent<IFoodSpawnUnit>();
        component.InjectDependency(signalBus, this, this); 
        return go;
    }

    [System.Serializable]
    public class Settings
    {
        public GameObject foodPrefab;
        public float yOffset;
        public int typeId;
        public Vector3 center;
        public Vector3 size;
        public int score =20;
    }
}


