using UnityEngine;
using Zenject;

public class FoodSpawnItem : MonoBehaviour, IFoodSpawnUnit
{
    private SignalBus signalBus;
    public IFoodUnit FoodUnit { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FoodHit" + collision.gameObject.tag);
        if (collision.gameObject.tag == "Snake")
        {
            DisptachOnFoodHit();
        }
    }

    public void InjectDependency(SignalBus signalBus, IFoodUnit foodUnit)
    {
        this.signalBus = signalBus;
        this.FoodUnit = foodUnit;
    }

    public void DisptachOnFoodHit()
    {
        signalBus.Fire(new OnFoodHitSignal(FoodUnit));
        Destroy(this.gameObject);
    }
}