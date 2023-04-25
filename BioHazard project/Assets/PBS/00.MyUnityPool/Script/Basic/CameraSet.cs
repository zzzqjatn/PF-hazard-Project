using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    public Vector3 Pos;
    public Vector3 Dir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            CameraManager2.Instance.SetCamera(Pos, Dir);
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
