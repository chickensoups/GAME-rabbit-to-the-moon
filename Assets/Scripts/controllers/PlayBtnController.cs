using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayBtnController : MonoBehaviour
{

    public Button playBtn;
    public Button googleBtn;
    public Button kongregateBtn;

    public void Start()
    {
        playBtn.onClick.AddListener(PlayBtnClick);
        googleBtn.onClick.AddListener(GoogleBtnClick);
        kongregateBtn.onClick.AddListener(KongregateBtnClick);
    }

    private void PlayBtnClick()
    {
        SceneManager.LoadScene(2);
    }

    private void GoogleBtnClick()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ctsoft.bomb");
    }

    private void KongregateBtnClick()
    {
        Application.OpenURL("https://www.kongregate.com/games/chickensoups/click-bomb");
    }
}

