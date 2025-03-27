using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject NewScore;
    public Button RestartButton;

    private void Start()
    {
        RestartButton.interactable = false;
        GameOverScreen.SetActive(false);
        NewScore.SetActive(false);
    }

    private void Update()
    {
        CheckHighScore();
        CheckIfGameStopped();

        // Hide new score pop-up when clicking anywhere
        if (Input.GetMouseButtonDown(0))
        {
            NewScore.SetActive(false);
        }
    }

    private void CheckHighScore()
    {
        if (GameManager.Instance.Score > PlayerPrefs.GetInt("HighScore"))
        {
            GameOverScreen.SetActive(true);
            StartCoroutine(PreventSkip(2));
            PlayerPrefs.SetInt("HighScore", GameManager.Instance.Score);
            PlayerPrefs.Save();
        }
    }

    private void CheckIfGameStopped()
    {
        if (!GameManager.Instance.IsGameRunning)
        {
            GameOverScreen.SetActive(true);
            StartCoroutine(EnableRestartButtonAfterDelay(1));
        }
    }

    private IEnumerator PreventSkip(int time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(EnableRestartButtonAfterDelay(1));
    }

    private IEnumerator EnableRestartButtonAfterDelay(int delay)
    {
        RestartButton.interactable = false;
        yield return new WaitForSeconds(delay);
        RestartButton.interactable = true;
    }
}
