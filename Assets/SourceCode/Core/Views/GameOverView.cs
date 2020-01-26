using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverView : View<GameOverView>
{
    [SerializeField] private Settings settings;

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public void InitView()
    {

    }

    private void ReturnHome()
    {

    }

    [System.Serializable]
    public class Settings
    {
        public TMP_Text txtCurrentScore;
        public TMP_Text txtHighScore;
        public Button btnHome;
    }
}
