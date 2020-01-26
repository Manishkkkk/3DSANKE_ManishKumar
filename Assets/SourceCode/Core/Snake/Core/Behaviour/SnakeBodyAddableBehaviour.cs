using System;
using UnityEngine;
using Zenject;

public class SnakeBodyAddableBehaviour : ISnakeBodyAddable, ITickable, IInitializable, IDisposable
{
    public ISnake Snake { get; private set; }

    private readonly SignalBus signalBus;
    private readonly SnakeSettings snakeSettings;

    public SnakeBodyAddableBehaviour(ISnake snake, SignalBus signalBus, SnakeSettings snakeSettings)
    {
        Snake = snake;
        this.snakeSettings = snakeSettings;
        this.signalBus = signalBus;
    }

    public void Initialize()
    {
        signalBus.Subscribe<OnFoodHitSignal>(AddSnakeBody);

        InitSnakeBody();
    }

    public void Dispose()
    {
        signalBus.Unsubscribe<OnFoodHitSignal>(AddSnakeBody);
    }

    private void InitSnakeBody()
    {
        for (int i = 0; i < snakeSettings.beginSize - 1; i++)
        {
            AddSnakeBody();
        }
    }

    private void AddSnakeBody()
    {
        var snakeTrsfrm = GenerateSnakeBody();
        Snake.AddBodyPart(snakeTrsfrm);
    }

    private Transform GenerateSnakeBody()
    {
        Transform newpart = (GameObject.Instantiate(snakeSettings.snakeBody, Snake.BodyPart[Snake.BodyPart.Count - 1].position, Snake.BodyPart[Snake.BodyPart.Count - 1].rotation) as GameObject).transform;
        var component = newpart.GetComponent<ISnakeBodyUnit>();
        component.InjectDependency(signalBus);
        //set theparent
        return newpart;
    }

    public void Tick()
    {
        if (Input.GetKey(KeyCode.Q))
            AddSnakeBody();
    }
}
