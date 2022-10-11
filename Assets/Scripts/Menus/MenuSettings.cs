using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class MenuSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public float sliderValue;

    public void Awake() {
        slider.value = PlayerPrefs.GetFloat("save", sliderValue);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void ChangeSlider(float value){
        sliderValue = value;
        PlayerPrefs.SetFloat("save", sliderValue);
    }
}