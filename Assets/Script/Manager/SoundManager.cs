using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioClip> clipList;

    public List<AudioSource> sources;

    public Slider BgmSlider;

    public Slider SfxSlider;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Assert.IsNotNull(BgmSlider, "Please Bgm Slider");
        Assert.IsNotNull(SfxSlider, "Please set Sfx Slider");

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sources[0].volume = PlayerPrefs.GetFloat("sfxVolume");
            SfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            sources[0].volume = 0.5f;
            SfxSlider.value = 0.5f;
            PlayerPrefs.SetFloat("sfxVolume", SfxSlider.value);
        }

        if (PlayerPrefs.HasKey("bgmVolume"))
        {
            sources[1].volume = PlayerPrefs.GetFloat("bgmVolume");
            BgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        }
        else
        {
            sources[1].volume = 0.6f;
            BgmSlider.value = 0.6f;
            PlayerPrefs.SetFloat("bgmVolume", BgmSlider.value);
            
        }
    }

    public void PlayClip(int clip)
    {
        sources[0].PlayOneShot(clipList[clip]);
    }

    public void ChangeVolumeSfx()
    {
        sources[0].volume = SfxSlider.value;
        PlayerPrefs.SetFloat("sfxVolume", SfxSlider.value);
    }

    public void ChangeVolumeBgm()
    {
        sources[1].volume = BgmSlider.value;
        PlayerPrefs.SetFloat("bgmVolume",BgmSlider.value);
    }
}
