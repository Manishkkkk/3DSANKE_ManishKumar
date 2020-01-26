using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class GamePlayView : View<GamePlayView>
{
    [SerializeField] private Settings settings;

    SignalBus signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        UpdateScore(0);
        signalBus.Subscribe<OnScoreUpdateSignal>(onScoreUpdateSignal);
        signalBus.Subscribe<OnStreakUpdateSignal>(OnStreakUpdateSignal);
    }

    public override void OnDisable()
    {
        signalBus.Unsubscribe<OnScoreUpdateSignal>(onScoreUpdateSignal);
        signalBus.Unsubscribe<OnStreakUpdateSignal>(OnStreakUpdateSignal);
        base.OnDisable();
    }

    private void onScoreUpdateSignal(OnScoreUpdateSignal onScoreUpdateSignal)
    {
        UpdateScore(onScoreUpdateSignal.score);
    }

    private void UpdateScore(int Score)
    {
        settings.txtScore.text = Score.ToString();
    }

    private void OnStreakUpdateSignal(OnStreakUpdateSignal onStreakUpdateSignal)
    {
        settings.txtStrekScore.gameObject.SetActive(true);
        settings.txtStrekScore.text = onStreakUpdateSignal.streakValue.ToString();
        LeanTween.scale(settings.txtStrekScore.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setFrom(Vector3.one).setOnComplete(()=> settings.txtStrekScore.gameObject.SetActive(false));
    }

    [System.Serializable]
    public class Settings
    {
        public TMP_Text txtScore;
        public TMP_Text txtStrekScore;
    }
}
