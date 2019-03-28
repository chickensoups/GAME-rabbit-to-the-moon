using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Level
{
    public int index;
    public TutorialContent tutorialContent;
    public List<LadderInfo> ladders;

    public Level()
    {

    }

    public Level(int index, TutorialContent tutorialContent, List<LadderInfo> ladders)
    {
        this.index = index;
        this.tutorialContent = tutorialContent;
        this.ladders = ladders;
    }
}
