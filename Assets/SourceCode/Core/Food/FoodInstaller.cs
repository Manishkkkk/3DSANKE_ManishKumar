using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "FoodInstaller", menuName = "Installers/FoodInstaller")]
public class FoodInstaller : ScriptableObjectInstaller<FoodInstaller>
{
    [SerializeField] private RedFood.Settings redFoodSettings;
    [SerializeField] private BlueFood.Settings bluefoodSettings;
    public override void InstallBindings()
    {
        Container.BindInstances(redFoodSettings);
        Container.BindInstances(bluefoodSettings);

        Container.Bind<IFood>().To<RedFood>().AsSingle().NonLazy();
        Container.Bind<IFood>().To<BlueFood>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<FoodSpawnBehaviour>().AsSingle().NonLazy();
    }
}


