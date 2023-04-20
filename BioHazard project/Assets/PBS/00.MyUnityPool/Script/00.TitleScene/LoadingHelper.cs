using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingHelper : MonoBehaviour
{
    private bool IsTrigger = false;
    private float timer = 0.0f;

    void Start()
    {
        IsTrigger = false;
        timer = 0.0f;
    }

    void Update()
    {
        if (IsTrigger)
        {
            FadeOutAndLoadStart();
        }
    }

    public void FadeOutTrigger()
    {
        IsTrigger = true;
    }
    private void FadeOutAndLoadStart()
    {
        timer += Time.deltaTime;

        GameObject loadimgObj = GFunc.GetRootObj("MainUI").FindChildObj("LoadingHelper");
        Image loadimg = loadimgObj.GetComponent<Image>();
        loadimgObj.SetActive(true);

        if (timer >= 0.01f)
        {
            if (loadimg.color.a < 1.0f)
            {
                Color temp = loadimg.color;
                temp.a += 0.01f;
                if (temp.a > 1.0f) temp.a = 1.0f;
                loadimg.color = temp;
            }
            else
            {
                //로딩씬으로
                IsTrigger = false;
                LoadingManager1.Instance.StartLoadingScene(LoadingManager1.S_GAME_NAME);
            }
            timer = 0.0f;
        }
    }
}
