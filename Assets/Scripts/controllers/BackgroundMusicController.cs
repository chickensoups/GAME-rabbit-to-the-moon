using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MySingleton<BackgroundMusicController>
{

    public AudioSource bgMusic;

    public void Start()
    {
        PlayerDataUtil.LoadPlayerData();
        // LevelUtil.printTutorialContent();
        if (PlayerDataUtil.playerData.soundEnabled)
        {
            bgMusic.Play();
        }
        else
        {
            bgMusic.Pause();
        }
    }
}

