using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider sliderMusic;
    public Slider sliderSFX;
    void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

    }
    public void SetMusicLevel()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderMusic.value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderMusic.value);
    }
    public void SetSFXLevel()
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderSFX.value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderSFX.value);
    }

}
