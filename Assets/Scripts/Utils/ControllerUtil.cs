﻿using UnityEngine;

public class ControllerUtil
{
    public static CoreController coreController;

    public static void init()
    {
        coreController = GameObject.Find("CoreController").GetComponent<CoreController>();
    }
}