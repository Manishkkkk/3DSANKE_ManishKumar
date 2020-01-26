using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuView : View<MainMenuView>
{
    [System.Serializable]
    public class Settings
    {
        public Button btnPlay;
        public TMP_Text txtHighScore;
    }
}
