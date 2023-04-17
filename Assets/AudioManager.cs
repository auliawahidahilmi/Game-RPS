using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    //property
    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => sfx.volume; }

    private void Start()
    {   
        //bgm
        if(bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }

        //sfx 
        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            bgm = sfxInstance;
        }
        else
        {
            sfxInstance = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
            bgm.Stop();
    
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if(sfx.isPlaying)
            sfx.Stop();

        sfx.clip = clip;
        sfx.Play();
    }

    public void SetMute(bool value)
    {
        bgm.mute = value;
        sfx.mute = value;
    }

    public void SetSfxVolume(float value)
    {
        sfx.volume = value;
    }
    public void SetBgmVolume(float value)
    {
        bgm.volume = value;
    }

}
