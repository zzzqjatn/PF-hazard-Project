using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBtn : MonoBehaviour
{
    public void OnClicked()
    {
        LoadingManager.Instance.FadeoutGotoScene(LoadingManager.S_GAME_NAME);
        // JsonLoadManager.Instance.SetSaveData(1);
    }
}
