using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DG.Tweening;

public class DesignLevelController : CoreController
{
    // override level data
    public bool overrideLevelData;
    Level backupLevel;
    public int levelIndex = 1;
    public TutorialContent tutorialContent;

    public void GenerateLevelData(bool withBackup=false)
    {
        Debug.Log(withBackup);
        if (withBackup)
        {
            level = backupLevel;
        }
        else
        {
            // Push all data to level
            List<LadderInfo> ladderInfos = new List<LadderInfo>();
            level = new Level(levelIndex, tutorialContent, ladderInfos);
            LevelUtil.setCurrentLevel(level);

            GameObject[] ladders = findGameObjectsWithTag(Constants.ObjectTags.ladder.ToString());
            for (int i = 0; i < ladders.Length; i++)
            {
                GameObject ladder = ladders[i];
                LadderInfo ladderInfo = new LadderInfo();
                Explode ladderExplode = ladder.GetComponent<Explode>();

                ladderInfo.initAngle = -1 * ladderExplode.initAngle;
                ladderInfo.type = Constants.LadderType.longLadder; // todo:
                ladderInfo.timeout = ladderExplode.timeout;

                LadderRotate ladderRotate = ladder.GetComponent<LadderRotate>();
                if (ladderRotate.speed > 0)
                {
                    ladderInfo.rotate = new LadderRotateData(ladderRotate.isClockwise, ladderRotate.speed);
                }
                else
                {
                    ladderInfo.rotate = null;
                }

                LadderMovement ladderMovement = ladder.GetComponent<LadderMovement>();
                if (ladderMovement.speed > 0)
                {
                    ladderInfo.initPosition.Fill(ladder.GetComponent<Explode>().initPosition);
                    MyVector3[] points = new MyVector3[ladderMovement.points.Count];
                    for (int j = 0; j < ladderMovement.points.Count; j++)
                    {
                        points[j] = new MyVector3();
                        points[j].Fill(ladderMovement.points[j]);
                    }
                    ladderInfo.movement = new LadderMovementData(ladderMovement.type, points, ladderMovement.distances, ladderMovement.speed, ladderMovement.radius, ladderMovement.isClockwise, ladderMovement.initAngle);
                }
                else
                {
                    ladderInfo.initPosition.Fill(ladder.transform.position);
                    ladderInfo.movement = null;
                }

                ladderInfos.Add(ladderInfo);
            }

            level.ladders = ladderInfos;
            backupLevel = level;
        }
    }

    public void SaveGeneratedData()
    {
        SaveLevelData(level);
    }

    public void SaveLevelData(Level level)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.dataPath + "/Resources/Levels/lv_" + level.index + ".txt";
        FileStream file = File.OpenWrite(destination);
        bf.Serialize(file, level);
        file.Close();
    }

    public override void Refresh(bool withBackup)
    {
        Debug.Log("refresh in design level controller");
        
        if (overrideLevelData)
        {
            Debug.Log("Override level data");
            level = null;
        }
        else
        {
            level = LevelUtil.LoadLevelData(levelIndex);
        }

        // If this level is already has, then load level data
        if (level == null)
        {
            GenerateLevelData(withBackup);
        }
        else
        {
            Debug.Log("Level it not null");
        }
    }
}
