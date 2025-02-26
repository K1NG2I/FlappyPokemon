using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Dragon_Normal;
    public GameObject Dragon_Blue, Dragon_Yellow;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Trigger()
    {
        StartGame.level = 0;
        FlyScript.IsGameStarted = true;
        if (ChangeSkin.SelectedDragon.Equals("Normal"))
        {
            Dragon_Normal.SetActive(true);
            Dragon_Blue.SetActive(false);
            Dragon_Yellow.SetActive(false);
        }
        if (ChangeSkin.SelectedDragon.Equals("Blue"))
        {
            Dragon_Normal.SetActive(false);
            Dragon_Blue.SetActive(true);
            Dragon_Yellow.SetActive(false);
        }
        if (ChangeSkin.SelectedDragon.Equals("Yellow"))
        {
            Dragon_Normal.SetActive(false);
            Dragon_Blue.SetActive(false);
            Dragon_Yellow.SetActive(true);
        }
        GameOverScreen.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
