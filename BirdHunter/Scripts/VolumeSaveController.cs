using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private Text volumeTextUI = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider (float volume)
    {
        volumeTextUI.text = volumeSlider.value.ToString("0.00");
    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("GameVolume", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("GameVolume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
