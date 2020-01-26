using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ScoreSystem
{
    public class ScoreManager : IInitializable, IDisposable, IScoreManager
    {
        private const string HighScoreConst = "HIGHSCORE";

        private int currentScore = 0;
        private int prevFoodId = 0;
        private int streak = 1;
        private int highScore = 0;
        private SignalBus signalBus;

        public int HighScore => highScore;

        public int CurrentScore { get => currentScore; }

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
            highScore = (PlayerPrefs.HasKey(HighScoreConst)) ? PlayerPrefs.GetInt(HighScoreConst) : 0;
        }

        public void Reset()
        {
            currentScore = 0;
            prevFoodId = 0;
            streak = 1;
        }

        private void OnFoodHit(OnFoodHitSignal onFoodHitSignal)
        {
            if (prevFoodId != onFoodHitSignal.foodUnit.TypeID)
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

            CheckForNewHighScore();
        }

        private void CheckForNewHighScore()
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt(HighScoreConst, highScore);
            }
        }
    }
}