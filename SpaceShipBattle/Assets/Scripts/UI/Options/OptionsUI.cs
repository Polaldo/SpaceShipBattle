using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Slider volumeMasterSlider;
    [SerializeField] private Slider volumeMusicSlider;
    [SerializeField] private Slider volumeSfxSlider;

    private void Start()
    {
        volumeMasterSlider.onValueChanged.AddListener((value) => AudioManager.instance.SetMasterVolume(value));
        volumeMusicSlider.onValueChanged.AddListener((value) => AudioManager.instance.SetMusicVolume(value));
        volumeSfxSlider.onValueChanged.AddListener((value) => AudioManager.instance.SetSFXVolume(value));
    }

}
