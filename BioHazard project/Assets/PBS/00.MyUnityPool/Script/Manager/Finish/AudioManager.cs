using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    // Bgm 이름 다 캐싱해놓기
    public const string RACCONCITY_N = "RacconCity";
    // Sfx 이름 다 캐싱해놓기
    public const string FOOTSTEP_N = "FootStep";
    private const int MAX_SFX = 10;

    [System.Serializable]
    private class Sound
    {
        public string name;
        public AudioClip clip;

        public Sound(string name_, AudioClip clip_)
        {
            this.name = name_;
            this.clip = clip_;
        }
    }

    [SerializeField] private List<Sound> BgmLoad;
    [SerializeField] private List<Sound> SfxLoad;

    [SerializeField] private AudioSource BgmPlayer;
    [SerializeField] private AudioSource[] SfxPlayer;

    protected override void Init()
    {
        BgmLoad = new List<Sound>();
        SfxLoad = new List<Sound>();

        AudioClip[] loadAudio = Resources.LoadAll<AudioClip>("PBS/Audio/BGM");

        if (loadAudio.Length != 0)
        {
            //BgmLoad
            for (int i = 0; i < loadAudio.Length; i++)
            {
                Sound soundtemp = new Sound(RACCONCITY_N + i, loadAudio[i]);
                BgmLoad.Add(soundtemp);
            }
        }

        loadAudio = Resources.LoadAll<AudioClip>("PBS/Audio/SFX/Footsteps");

        if (loadAudio.Length != 0)
        {
            for (int i = 0; i < loadAudio.Length; i++)
            {
                Sound soundtemp = new Sound(FOOTSTEP_N + i, loadAudio[i]);
                SfxLoad.Add(soundtemp);
            }
        }

        GameObject BGMTemp = gameObject.FindChildObj("BGMPlayer");
        GameObject SFXTemp = gameObject.FindChildObj("SFXPlayer");

        BgmPlayer = BGMTemp.AddComponent<AudioSource>();
        SfxPlayer = new AudioSource[MAX_SFX];

        for (int i = 0; i < MAX_SFX; i++)
        {
            SfxPlayer[i] = SFXTemp.AddComponent<AudioSource>();
        }
    }

    public void PlayBgm(string BgmName)
    {
        if (BgmLoad.Count != 0)
        {
            for (int i = 0; i < BgmLoad.Count; i++)
            {
                if (BgmLoad[i].name.Equals(BgmName))
                {
                    BgmPlayer.clip = BgmLoad[i].clip;
                    BgmPlayer.Play();
                }
            }
        }
    }
    public void StopBgm()
    {
        BgmPlayer.Stop();
    }

    public void PlaySfx(string SfxName)
    {
        if (SfxLoad.Count != 0)
        {
            for (int i = 0; i < SfxLoad.Count; i++)
            {
                if (SfxLoad[i].name.Equals(SfxName))
                {
                    for (int j = 0; j < SfxPlayer.Length; j++)
                    {
                        if (SfxPlayer[j].isPlaying == false)
                        {
                            SfxPlayer[j].clip = SfxLoad[i].clip;
                            SfxPlayer[j].Play();
                            return;
                        }
                    }
                }
            }
        }
    }

    public void StopAllSfx()
    {
        for (int j = 0; j < SfxPlayer.Length; j++)
        {
            if (SfxPlayer[j].isPlaying == true)
            {
                SfxPlayer[j].Stop();
            }
        }
    }
}
