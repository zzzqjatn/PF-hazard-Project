using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInfo : MonoBehaviour
{
    private EffectType effectType;
    private ParticleSystem effect;
    private bool IsLooping;

    void Update()
    {
        if (!IsLooping && effect.isStopped)
        {
            EffectManager.Instance.StopEffect(this.gameObject, effectType);
        }
    }

    public void EffectInit(Vector3 pos, Quaternion dir, EffectType effectType_, bool looping, Transform parant = null)
    {
        effect = gameObject.GetComponent<ParticleSystem>();

        this.transform.position = pos;
        this.transform.rotation = dir;
        effectType = effectType_;

        if (parant != null) effect.transform.SetParent(parant);

        IsLooping = looping;

        effect.loop = IsLooping;

        effect.Play();
    }
}
