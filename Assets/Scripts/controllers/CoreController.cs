using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;

public abstract class CoreController : MonoBehaviour
{
    // Level
    public Level level;

    // Panel
    public GameObject buttonPanel;

    #region Init and Update methods
    protected void InitData()
    {
        // init data stuff
    }

    #endregion

    #region mono behavior methods

    void Awake()
    {
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData();
    }

    // Use this for initialization
    void Start()
    {
        ControllerUtil.init();
        LevelUtil.init();
        Refresh();
    }

    public abstract void Refresh(bool withBackup = false);

    // Update is called once per frame
    protected void Update()
    {
        EndGameLogic(1.0f);
    }

    #endregion

    // All logic when end a game level
    public void EndGameLogic(float delay)
    {
    }


    #region Utilities methods
    protected GameObject[] findGameObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    #endregion
}