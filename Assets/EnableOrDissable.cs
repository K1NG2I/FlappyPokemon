using UnityEngine;
using UnityEngine.UI;

public class EnableOrDissable : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject LandingPage;
    public GameObject SoundSetting;
    public GameObject SelectSkin;
    public GameObject MainScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Trigger()
    {
        if (LandingPage.activeInHierarchy != false)
        {
            if (LevelSelect.activeInHierarchy == false)
            {
                LevelSelect.SetActive(true);
                LandingPage.SetActive(false);
                SoundSetting.SetActive(false);
                SelectSkin.SetActive(false);
            }
            else
            {
                LevelSelect.SetActive(false);
                LandingPage.SetActive(true);
                MainScore.SetActive(true);
                SelectSkin.SetActive(false);
                SoundSetting.SetActive(false);
            }
        }
        else
        {
            LevelSelect.SetActive(false);
            LandingPage.SetActive(true);
            MainScore.SetActive(true);
            SoundSetting.SetActive(false);
            SelectSkin.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
