using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//Refactor this scriipt
public class ScoreManager : IInitializable, IDisposable
{
    private const string HighScoreConst = "HIGHSCORE";
    SignalBus signalBus;

    private  int currentScore = 0;
    private int prevFoodId = 0;
    private int streak = 1;
    private int highScore = 0;
    public int HighScore  => highScore; 

    public int CurrentScore { get => currentScore;  }

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }
    public void Dispose()
    {
        signalBus.Unsubscribe<OnFoodHitSignal>(OnFoodHit);
    }

    public void Initialize()
    {
        signalBus.Subscribe<OnFoodHitSignal>(OnFoodHit);
        LoadHighScore();
    }

    private void LoadHighScore()
    {
        if(PlayerPrefs.HasKey(HighScoreConst))
        {
            highScore = PlayerPrefs.GetInt(HighScoreConst);
        }
        else
        {
            highScore = 0;
        }

    }

    public void Reset()
    {
        currentScore = 0;
        prevFoodId = 0;
        streak = 1;
    }

    private void OnFoodHit(OnFoodHitSignal onFoodHitSignal)
    {
        if(prevFoodId != onFoodHitSignal.foodUnit.TypeID)
        {
            prevFoodId = onFoodHitSignal.foodUnit.TypeID;
            streak = 1;
            currentScore += onFoodHitSignal.foodScore.Score;
            signalBus.Fire(new OnScoreUpdateSignal(currentScore));
        }
        else
        {
            streak += 1;
            var score = onFoodHitSignal.foodScore.Score * streak;
            currentScore += score;
            signalBus.Fire(new OnStreakUpdateSignal(streak));
            signalBus.Fire(new OnScoreUpdateSignal(currentScore));
        }

        if(currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScoreConst, highScore);
        }
    }
}
