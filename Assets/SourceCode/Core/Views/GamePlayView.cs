using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayView : View<GamePlayView>
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

    [System.Serializable]
    public class Settings
    {
        public TMP_Text txtScore;
        public TMP_Text txtStrekScore;
    }
}
