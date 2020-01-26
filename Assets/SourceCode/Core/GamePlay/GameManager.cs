using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum GameState
{
    Start,
    Process,
    End
}

public class GameManager : MonoBehaviour, IInitializable
{
    public GameState gameState = GameState.Start;

    public void Initialize()
    {
        gameState = GameState.Process;
    }
}
