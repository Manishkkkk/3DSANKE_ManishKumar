using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewInstaller : Installer<ViewInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ViewController>().AsSingle().NonLazy();
    }
}
