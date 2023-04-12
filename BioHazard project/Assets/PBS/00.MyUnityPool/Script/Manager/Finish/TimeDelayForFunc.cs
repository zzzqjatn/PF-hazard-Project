using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelayForFunc : MonoBehaviour
{
    private float Delay;
    public bool IsPlaying;

    public TimeDelayForFunc()
    {
        IsPlaying = true;
    }

    public void StartDelay(float delay_)
    {
        StartCoroutine(DelayCourutin(delay_));
    }

    public IEnumerator DelayCourutin(float delay_)
    {
        IsPlaying = false;
        yield return new WaitForSeconds(delay_);
        IsPlaying = true;
    }
}
