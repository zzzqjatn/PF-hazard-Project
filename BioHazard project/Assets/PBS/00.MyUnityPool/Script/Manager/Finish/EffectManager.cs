using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    private const int GUN_FIRE_EFFECT_MAX = 8;
    private const int BLOOD_SPOT_EFFECT_MAX = 20;
    private Dictionary<EffectType, Stack<GameObject>> EffectDic;
    public ParticleSystem BulletShellEffectPrefab;
    public ParticleSystem GunFireEffectPrefab;
    public ParticleSystem BloodSpotEffectPrefab;

    protected override void Init()
    {
        EffectDic = new Dictionary<EffectType, Stack<GameObject>>();

        InitDataForDict_Stack(GunFireEffectPrefab, GUN_FIRE_EFFECT_MAX, EffectType.GunFire);
        InitDataForDict_Stack(BulletShellEffectPrefab, GUN_FIRE_EFFECT_MAX, EffectType.BulletShell);
        InitDataForDict_Stack(BloodSpotEffectPrefab, BLOOD_SPOT_EFFECT_MAX, EffectType.BloodSpot);
    }

    private void InitDataForDict_Stack(ParticleSystem Prefabs, int loopCount, EffectType type)
    {
        Stack<GameObject> objPool = new Stack<GameObject>();

        for (int i = 0; i < loopCount; i++)
        {
            GameObject effect = Instantiate(Prefabs.gameObject, Vector3.zero, Quaternion.identity, this.transform);
            effect.SetActive(false);
            objPool.Push(effect);
        }
        EffectDic.Add(type, objPool);
    }

    public void PlayEffect(Vector3 pos, Vector3 nomal, bool looping, EffectType effectType)
    {
        Stack<GameObject> objPool = null;

        if (EffectDic.TryGetValue(effectType, out objPool))
        {
            if (objPool.Count > 0)
            {
                GameObject obj = objPool.Pop();
                obj.SetActive(true);
                obj.GetComponent<EffectInfo>().EffectInit(pos, Quaternion.LookRotation(nomal), effectType, looping, this.transform);
            }
        }
    }
    public void StopEffect(GameObject obj, EffectType effectType)
    {
        Stack<GameObject> objPool = null;

        if (EffectDic.TryGetValue(effectType, out objPool))
        {
            obj.SetActive(false);
            objPool.Push(obj);
        }
    }
}

public enum EffectType
{
    None,
    BulletShell,
    GunFire,
    BloodSpot
}