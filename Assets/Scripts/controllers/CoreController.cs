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

    // Level
    public Level nextLevel;

    // Panel
    public GameObject buttonPanel;

    // Character
    public GameObject character;

    // Current ladder index
    public int currentLadderIndex = 1;

    #region Init and Update methods
    protected void InitData()
    {
        // init data stuff
        InitCharacter();
    }

    protected void InitCharacter()
    {
        // move character to the first ladder position
        character.transform.position = level.ladders[0].initPosition.GetV3();
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
        InitData();
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

    public bool IsCurrentLadderIsLast()
    {
        return currentLadderIndex == level.ladders.Count;
    }

    public void JumpDoneValidate()
    {
        if(IsCurrentLadderIsLast())
        {
            AudioManager.Instance.playSound(Constants.ResourcesName.winSound);

            // Save unlocked checkpoint to player data
            PlayerDataUtil.playerData.unlockedCheckpoint++;
            PlayerDataUtil.SavePlayerData();

            // Load next level
            Level level = LevelUtil.LoadLevelData(LevelUtil.getCurrentLevel().index + 1);
            LevelUtil.setCurrentLevel(level);
            Refresh();
        }
    }

    protected void DestroyAllLadder()
    {
        GameObject[] objs = GameObjectUtils.FindGameObjectsWithTag(Constants.ObjectTags.ladder.ToString());
        foreach(GameObject obj in objs)
        {
            Destroy(obj);
        }
    }
}