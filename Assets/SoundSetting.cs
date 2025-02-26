using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public Slider SoundSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void SetVolume()
    {
        AudioListener.volume = SoundSlider.value;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
