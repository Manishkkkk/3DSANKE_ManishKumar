using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
using UnityEngine.SceneManagement;
using Frame.Views;
using Core.ScoreSystem;

namespace Core.Views
{
    public class GameOverView : View<GameOverView>
    {
        [SerializeField] private Settings settings;

        public string sceneName = "MainMenu";
        private ZenjectSceneLoader _sceneLoader;
        private ScoreManager scoreManager;

        [Inject]
        private void Construct(ZenjectSceneLoader sceneLoader, ScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;
            _sceneLoader = sceneLoader;
        }

        public override void OnEnable()
        {
            settings.btnHome.onClick.AddListener(ReturnHome);
            InitView();
            base.OnEnable();
        }

        public override void OnDisable()
        {
            settings.btnHome.onClick.RemoveListener(ReturnHome);
            base.OnDisable();
        }

        public void InitView()
        {
            settings.txtCurrentScore.text = "Score: " + scoreManager.CurrentScore;
            settings.txtHighScore.text = "High Score: " + scoreManager.HighScore;
        }

        private void ReturnHome()
        {
            _sceneLoader.LoadScene(sceneName, LoadSceneMode.Single);
        }

        [System.Serializable]
        public class Settings
        {
            public TMP_Text txtCurrentScore;
            public TMP_Text txtHighScore;
            public Button btnHome;
        }
    }
}