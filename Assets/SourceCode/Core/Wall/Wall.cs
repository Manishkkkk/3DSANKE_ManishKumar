using UnityEngine;
using Zenject;

public class Wall : MonoBehaviour, IWallUnit
{
    [Inject]
    private SignalBus signalBus;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Snake")
        {
            OnSnakeHit();
        }
    }
    public void OnSnakeHit()
    {
        Debug.Log("On wall hit signal");
        signalBus.Fire<OnSnakeWallHitSignal>();
    }
}
