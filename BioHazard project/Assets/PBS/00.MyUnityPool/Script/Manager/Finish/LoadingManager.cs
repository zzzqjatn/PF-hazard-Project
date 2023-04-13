using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    // public const string S_LOAD_NAME = "01.LoadingScene";
    public const string S_TITLE_NAME = "00.TitleScene";
    public const string S_GAME_NAME = "02.GameScene";

    private GameObject loadTxt;
    private GameObject fadeOutImg;
    private LoadTxtType loadTxtType;
    private AsyncOperation operation;
    private bool fadeOut;

    public void FadeoutGotoScene(string sceneName)
    {
        fadeOut = false;
        loadTxt = this.gameObject.FindChildObj("LoadTxt");
        fadeOutImg = this.gameObject.FindChildObj("FadeOutImage");
        fadeOutImg.SetActive(true);
        loadTxtType = LoadTxtType.T1;
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string input)
    {
        operation = SceneManager.LoadSceneAsync(input);
        operation.allowSceneActivation = false;

        Image loadimg = fadeOutImg.GetComponent<Image>();

        float timer = 0.0f;
        bool oneCycle = false;

        while (!operation.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (fadeOut == true)
            {
                if (oneCycle == false || operation.progress < 0.9f) // Max 1.0f
                {
                    if (timer >= 0.2f)
                    {
                        switch (loadTxtType)
                        {
                            case LoadTxtType.T1:
                                loadTxt.SetTxt("Now Loading");
                                break;
                            case LoadTxtType.T2:
                                loadTxt.SetTxt("Now Loading.");
                                break;
                            case LoadTxtType.T3:
                                loadTxt.SetTxt("Now Loading..");
                                break;
                            case LoadTxtType.T4:
                                loadTxt.SetTxt("Now Loading...");
                                oneCycle = true;
                                break;
                        }

                        loadTxtType += 1;
                        if ((int)loadTxtType >= 4) loadTxtType = 0;

                        timer = 0.0f;
                    }
                }
                else
                {
                    break;
                }
            }
            else if (fadeOut == false)
            {
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
                        fadeOut = true;
                        loadTxt.SetActive(true);
                    }
                    timer = 0.0f;
                }
            }
        }
        // 여기서 화면은 넘기지만 비동기 특징? 같은
        // 장면 로딩이 조금 느려서
        operation.allowSceneActivation = true;

        yield return new WaitForSeconds(0.3f);
        //가려준 상태로 0.3초 기달려주고 끈다.
        // ReSet
        loadTxt.SetActive(false);
        fadeOutImg.SetActive(false);
        Color ttemp = loadimg.color;
        ttemp.a = 0.0f;
        loadimg.color = ttemp;
        //여기서 json 형식으로 저장된 데이터 게임씬에
    }

    public enum LoadTxtType
    {
        T1,
        T2,
        T3,
        T4
    }
}