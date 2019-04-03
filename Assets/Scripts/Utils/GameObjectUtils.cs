using UnityEngine;
using System.Collections;
using System;

public class GameObjectUtils
{
    public static GameObject[] FindGameObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    public static GameObject[] SortGameObjectByPositionY(GameObject [] objs)
    {
        for(int i=0; i<objs.Length-1; i++)
        {
            for (int j=i; j<objs.Length; j++)
            {
                if(objs[i].transform.position.y > objs[j].transform.position.y)
                {
                    GameObject tmp = objs[i];
                    objs[i] = objs[j];
                    objs[j] = tmp;
                }
            }
        }
        return objs;
    }
}
