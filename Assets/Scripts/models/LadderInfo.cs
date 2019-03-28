using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class LadderInfo {
    public Constants.LadderType type;
    public MyVector3 initPosition;
    public float initAngle;
    public LadderMovementData movement;
    public LadderRotateData rotate;
    public float timeout;

    public LadderInfo()
    {
        initAngle = 0;
        timeout = 0;
        initPosition = new MyVector3();
    }

    public LadderInfo(LadderInfo other)
    {
        this.type = other.type;
        this.initPosition = other.initPosition;
        this.initAngle = other.initAngle;
        this.timeout = other.timeout;

        this.movement = other.movement;
        this.rotate = other.rotate;
    }

    public LadderInfo(Constants.LadderType type, MyVector3 initPosition, float initAngle, float timeout, LadderMovementData movement, LadderRotateData rotate)
    {
        this.type = type;
        this.initPosition = initPosition;
        this.initAngle = initAngle;
        this.timeout = timeout;

        this.movement = movement;
        this.rotate = rotate;
    }
}
