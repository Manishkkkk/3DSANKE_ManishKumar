using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SnakeSignalsInstaller.Install(Container);
    }
}