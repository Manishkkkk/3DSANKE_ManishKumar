using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GamePlayView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameOverView>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<GameController>().AsSingle().NonLazy();
    }
}