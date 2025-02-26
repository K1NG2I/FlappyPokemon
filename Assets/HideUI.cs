using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject LandingPage;
    public GameObject SoundSetting;
    public GameObject SelectSkin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Trigger()
    {
        LandingPage.SetActive(false);
        LevelSelect.SetActive(false);
        SoundSetting.SetActive(false);
        SelectSkin.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
