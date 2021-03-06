﻿using Core.Gameplay;
using UnityEngine;
using Zenject;
namespace Core.Snake
{
    public class SnakeInstaller : MonoInstaller<SnakeInstaller>
    {
        [SerializeField] private SnakeSettings snakeSettings;
        public override void InstallBindings()
        {
            Container.BindInstance(snakeSettings);
            Container.Bind<ISnake>().To<Snake>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SnakeMovementBehaviour>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SnakeBodyAddableBehaviour>().AsSingle().NonLazy();
        }
    }
}