using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using UnityEngine.SceneManagement;

public class MainMenuView : View<MainMenuView>, IInitializable
{
    [SerializeField] private Settings settings;

    [Inject]
    ScoreManager scoreManager;
    [Inject]
    private ZenjectSceneLoader _sceneLoader;
    public string sceneName = "GameScene";

    public override void OnEnable()
    {
        settings.btnPlay.onClick.AddListener(OnPlayClick);
        base.OnEnable();
    }

    public override void OnDisable()
    {
        settings.btnPlay.onClick.RemoveListener(OnPlayClick);
        base.OnDisable();
    }

    public void InitView()
    {
        settings.txtHighScore.text = "High Score: "+scoreManager.HighScore.ToString();
    }

    private void OnPlayClick()
    {
        scoreManager.Reset();
        _sceneLoader.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Initialize()
    {
        InitView();
    }

    [System.Serializable]
    public class Settings
    {
        public Button btnPlay;
        public TMP_Text txtHighScore;
    }
}
