using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject LevelSelect;
    public GameObject SoundSetting;
    public GameObject GameOverScreen;
    public GameObject SelectSkin;
    public GameObject NewScore;
    public GameObject DragonBlue, DragonYellow;
    public static bool canPressButton = true;
    public Button RestartButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RestartButton.interactable = false;
        LevelSelect.SetActive(false);
        SoundSetting.SetActive(false);
        SelectSkin.SetActive(false);
        GameOverScreen.SetActive(false);
        NewScore.SetActive(false);
        DragonBlue.SetActive(false);
        DragonYellow.SetActive(false);
    }

    public void ChecHighScore()
    {
        if (FlyScript.sethighscore == true)
        {
            GameOverScreen.SetActive(true);
            StartCoroutine(PreventSkip(2));
            FlyScript.sethighscore = false; 
        }
    }
    public void CheckIsGameStopped()
    {
        if (FlyScript.IsGameStopped == true)
        {
            GameOverScreen.SetActive(true);
            StartCoroutine(EnableRestartButtonAfterDelay(1));
            FlyScript.IsGameStopped = false;
        }
    }
    IEnumerator PreventSkip(int time)
    {
        canPressButton = false;
        yield return new WaitForSeconds(time);
        StartCoroutine(EnableRestartButtonAfterDelay(1));
        canPressButton = true;
    }
    IEnumerator EnableRestartButtonAfterDelay(int delay)
    {
        RestartButton.interactable = false;
        yield return new WaitForSeconds(delay);
        RestartButton.interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        ChecHighScore();
        CheckIsGameStopped();
        if (Input.GetMouseButtonDown(0) && canPressButton)
        {
            NewScore.SetActive(false);
            
        }
    }
}
