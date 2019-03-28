﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelUtil
{
    private static Level currentLevel;

    public static void init()
    {
        //PlayerDataUtil.playerData.unlockedLevelIndex = 60;
        if (currentLevel == null)
        {
            currentLevel = LoadLevelData(PlayerDataUtil.playerData.unlockedCheckpoint);
        }
    }

    public static Level getCurrentLevel()
    {
        if(currentLevel == null)
        {
            currentLevel = LoadLevelData(1);
        }
        return currentLevel;
    }

    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static Level LoadLevelData(int index)
    {
        BinaryFormatter bf = new BinaryFormatter();
        TextAsset asset = Resources.Load<TextAsset>("Levels/lv_" + index);
        if (asset == null)
        {
            return null;
        }
        Stream stream = new MemoryStream(asset.bytes);
        Level levelToLoad = (Level)bf.Deserialize(stream);
        stream.Close();
        currentLevel = levelToLoad;
        return levelToLoad;
    }

    public static void printTutorialContent()
    {
        for (int i=1; i<61; i++)
        {
            Level level = LoadLevelData(i);
            if (level.tutorialContent.descriptions != string.Empty)
            {
                Debug.LogError("============");
                Debug.LogError("level " + i);
                Debug.LogError(level.tutorialContent.image);
                Debug.LogError(level.tutorialContent.descriptions);
            }

        }
    }
}
