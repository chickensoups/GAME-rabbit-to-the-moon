using UnityEngine;
using System;

[Serializable]
public class LadderRotateData: RotateData
{
    public LadderRotateData(): base()
    {
    }

    public LadderRotateData(bool isClockwise, float speed): base(isClockwise, speed)
    {
    }
}