using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsColliderHit : MonoBehaviour
{
    public bool IsOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            IsOn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            IsOn = false;
        }
    }
}
