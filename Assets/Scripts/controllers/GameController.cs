using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : CoreController
{
    void MainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
        }
    }

    public override void Refresh(bool withBackup)
    {
        Debug.Log("Refresh in Game controller");
        SceneManager.sceneLoaded += MainSceneLoaded;

        level = LevelUtil.getCurrentLevel();
    }
}
