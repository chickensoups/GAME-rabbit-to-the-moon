using UnityEngine;
using System.Collections;

public abstract class Ladder : MonoBehaviour
{

    public Constants.LadderType type;
    public float initAngle;
    public Vector3 initPosition;
    public string particleName;
    public float timeout;

    public virtual void Start()
    {

    }

    public virtual void setLadderData(LadderInfo ladderInfo)
    {
        // rotate by init angle
        initAngle = ladderInfo.initAngle;
        transform.Rotate(0, 0, -initAngle);
        initPosition = ladderInfo.initPosition.GetV3();
        type = ladderInfo.type;
        timeout = ladderInfo.timeout;

        if (ladderInfo.movement == null || ladderInfo.movement.speed <= 0)
        {
            GetComponent<LadderMovement>().enabled = false;
        }
        else
        {
            GetComponent<LadderMovement>().enabled = true;
            GetComponent<LadderMovement>().SetMovementData(ladderInfo.movement);
        }

        if (ladderInfo.rotate == null || ladderInfo.rotate.speed <= 0)
        {
            GetComponent<LadderRotate>().enabled = false;
        }
        else
        {
            GetComponent<LadderRotate>().enabled = true;
            GetComponent<LadderRotate>().SetRotateData(ladderInfo.rotate);
        }
    }
}
