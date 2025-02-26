using UnityEngine;

public class StartGame : MonoBehaviour
{
    public static int level;
    public static int Recentlevel;
    public GameObject Dragon_Normal;
    public GameObject Dragon_Blue;
    public GameObject Dragon_Yellow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Trigger()
    {
        FlyScript.IsGameStarted = true;
        if (ChangeSkin.SelectedDragon.Equals("Normal")) {
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

    }
    public void SetLevel1()
    {
        level = 1;
        Recentlevel = level;
    }
   

}
