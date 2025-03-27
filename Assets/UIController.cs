using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    private Dictionary<string, GameObject> _uiElements;

    public GameObject LevelSelect;
    public GameObject LandingPage;
    public GameObject SoundSetting;
    public GameObject SelectSkin;
    public GameObject MainFrame;
    public GameObject BestScore;
    public GameObject NewScore;
    public GameObject GameOver;
    public GameObject TapToPlay;
    public Slider SoundSlider;

    private void Awake()
    {
        // Store all UI elements in a dictionary for easier toggling
        _uiElements = new Dictionary<string, GameObject>
        {
            { "LevelSelect", LevelSelect },
            { "LandingPage", LandingPage },
            { "SoundSetting", SoundSetting },
            { "NewScore", NewScore },
            { "SelectSkin", SelectSkin },
            { "GameOver", GameOver },
            { "MainFrame", MainFrame },
            { "TapToPlay", TapToPlay },
            { "BestScore", BestScore}
        };

        // Load saved volume setting
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = savedVolume;
            if (SoundSlider != null)
            {
                SoundSlider.value = savedVolume;
            }
        }
    }

    public void ToggleUIOn(string uiElement)
    {
        foreach (var element in _uiElements)
        {
            //element.Value.SetActive(element.Key == uiElement);
            if (uiElement == element.Key)
            {
                element.Value.SetActive(true);
            }
        }
    }
    public void ToggleUIOff(string uiElement)
    {
        foreach (var element in _uiElements)
        {
            //element.Value.SetActive(element.Key == uiElement);
            if (uiElement == element.Key)
            {
                element.Value.SetActive(false);
            }
        }
    }

    public void HideAllUI(string uiElement)
    {
        foreach (var element in _uiElements)
        {
            if (uiElement == element.Key)
            {
                element.Value.SetActive(true);
            }
            else
            {
                element.Value.SetActive(false);
            }
        }
        
    }

    // ?? This replaces SoundSetting.SetVolume()
    public void SetVolume()
    {
        AudioListener.volume = SoundSlider.value;
        PlayerPrefs.SetFloat("Volume", SoundSlider.value);
        PlayerPrefs.Save();
    }
}
