using Zenject;

public class SnakeSignalsInstaller : Installer<SnakeSignalsInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<OnFoodHitSignal>();
        Container.DeclareSignal<OnSnakeWallHitSignal>();
        Container.DeclareSignal<OnSnakeBodyHitSignal>();
        Container.DeclareSignal<OnScoreUpdateSignal>();
        Container.DeclareSignal<OnStreakUpdateSignal>();
    }
}
