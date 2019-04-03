using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CharacterController : MySingleton<CharacterController>
{
    public bool isMoving = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) && !isMoving)
        {
            if(ControllerUtil.coreController.IsCurrentLadderIsLast())
            {
                return;
            }
            isMoving = true;
            Vector3 end = ControllerUtil.coreController.level.ladders[ControllerUtil.coreController.currentLadderIndex++].initPosition.GetV3();
            transform.DOJump(end, 2, 1, 0.5f).OnComplete(JumpDone);
        }
    }

    private void JumpDone()
    {
        isMoving = false;
        ControllerUtil.coreController.JumpDoneValidate();
    }
}
