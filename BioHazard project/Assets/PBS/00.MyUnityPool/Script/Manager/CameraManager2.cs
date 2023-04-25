using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager2 : Singleton<CameraManager2>
{
    public void SetCamera(Vector3 pos, Vector3 dir)
    {
        Camera.main.transform.position = pos;
        Camera.main.transform.rotation = Quaternion.Euler(dir);
    }
}