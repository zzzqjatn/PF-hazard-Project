using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    //여기 만들면 됨

    public static GameObject GetRootObj()
    {
        GameObject Result = default;

        return Result;
    }

    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }
}
