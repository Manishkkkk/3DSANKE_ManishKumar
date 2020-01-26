using UnityEngine;
using Zenject;

public class Wall : MonoBehaviour, IWallUnit
{
    private SignalBus signalBus;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Snake")
        {
            OnSnakeHit();
        }
    }
    public void OnSnakeHit()
    {
        signalBus.Fire<OnSnakeWallHitSignal>();
    }
}
