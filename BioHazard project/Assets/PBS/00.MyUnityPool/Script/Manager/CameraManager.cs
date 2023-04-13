using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Camera C_Main;
    private float[] checkBox;

    protected override void Init()
    {
        C_Main = Camera.main;
    }

    public void Set_C_Main(Vector3 pos, Vector3 dir, float distance)
    {
        C_Main.transform.position = pos;
        C_Main.transform.rotation = Quaternion.LookRotation(dir);
    }
}

[System.Serializable]
public class CameraData
{
    /**
    사각형의 8 지점 값
    위
    0 : 좌측 상단 앞
    1 : 우측 상단 앞
    2 : 좌측 상단 뒤
    3 : 우측 상단 뒤
    
    아래
    4 : 좌측 하단 앞
    5 : 우측 하단 앞
    6 : 좌측 하단 뒤
    7 : 우측 하단 뒤
    */
    public float[] dotPoint;
    public Vector3 C_Pos;
    public Vector3 C_Rot;
    public CameraData(Vector3 pos, Vector3 rot, float[] dots)
    {
        dotPoint = new float[8];
        C_Pos = pos;
        C_Rot = rot;
        dotPoint = dots;
    }
}
