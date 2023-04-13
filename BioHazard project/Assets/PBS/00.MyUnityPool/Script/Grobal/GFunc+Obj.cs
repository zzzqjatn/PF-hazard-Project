using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;

public static partial class GFunc
{
    public static void SetTxt(this GameObject obj, string inputText)
    {
        TMP_Text txtTemp = obj.GetComponent<TMP_Text>();
        txtTemp.text = inputText;
    }

    public static GameObject GetRootObj(string targetRoot)
    {
        Scene activeScene = GetActiveScene();
        GameObject[] rootObjs = activeScene.GetRootGameObjects();

        GameObject result = default;
        foreach (GameObject rootObj in rootObjs)
        {
            if (rootObj.name.Equals(targetRoot))
            {
                result = rootObj;
                return result;
            }
            else { continue; }
        }
        return result;
    }   // GetRootObj()

    public static GameObject FindChildObj(this GameObject obj, string targetChildName)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            searchTarget = obj.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(targetChildName))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, targetChildName);

                if (searchResult == null || searchResult == default) { /* Pass */ }
                else { return searchResult; }
            }
        }
        return searchResult;
    }   // FindChildObj()

    public static Scene GetActiveScene()
    {
        return SceneManager.GetActiveScene();
    }   // GetActiveScene()
}
