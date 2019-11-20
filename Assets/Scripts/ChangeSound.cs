using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class ChangeSound : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider slider;
    //void Start()
    //{
    //    slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.95f);
    //}
    public void SetMusicLevel()
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(slider.value) * 20);
        //Debug.Log(slider.value);
        //PlayerPrefs.SetFloat("MusicVolume", values);
    }
    public void SetSFXLevel()
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(slider.value) * 20);
    }

}
