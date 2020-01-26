using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : IInitializable, IDisposable
{
    SignalBus signalBus;
    GameOverView GameOverView;
    GameManager gameManager;

    public GameController(SignalBus signalBus, GameOverView gameOverView, GameManager gameManager) 
    {
        this.gameManager = gameManager;
        this.signalBus = signalBus;
        GameOverView = gameOverView;
    }

    public void Dispose()
    {
        signalBus.Unsubscribe<OnSnakeWallHitSignal>(LoseGame);
    }

    public void Initialize()
    {
        signalBus.Subscribe<OnSnakeWallHitSignal>(LoseGame);
    }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    private void LoseGame()
    {
        //Fire a lose game Signal
        //Open the game over view
        Debug.Log("Game Over called");
        GameOverView.Open();
        gameManager.gameState = GameState.End;
    }


}
