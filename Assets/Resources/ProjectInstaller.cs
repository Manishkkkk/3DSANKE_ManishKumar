using Core.ScoreSystem;
using Frame.Views;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        ViewInstaller.Install(Container);
        SnakeSignalsInstaller.Install(Container);
        Container.BindExecutionOrder<ScoreManager>(-100);
        Container.BindInterfacesAndSelfTo<ScoreManager>().AsSingle().NonLazy();
    }
}