using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public bool IsBlueUnlocked;
    public bool IsYellowUnlocked;
    public static string SelectedDragon;
    public GameObject Lock1,Lock2,Lock_1, Lock_2, Dragon_Blue, Dragon_Yellow;
    public GameObject Dragon_Normal;
    public GameObject SSfB, SnSfB, SSfN, SnSfN;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectedDragon = "Normal";
        Dragon_Normal.SetActive(false);
        IsBlueUnlocked = false;
        IsYellowUnlocked = false;
        Lock1.SetActive(true);
        Lock2.SetActive(true);
        Lock_1.SetActive(false);
        Lock_2.SetActive(false);
        SSfN.SetActive(true);
        SnSfN.SetActive(false);
        SSfB.SetActive(false);
        SnSfB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 10)
        {
            Unlock("Blue");
        }
        if (PlayerPrefs.GetInt("HighScore") >= 25)
        {
            IsBlueUnlocked = true;
            Unlock("Yellow");
        }
    }

    public void Unlock(string color)
    {
        if (color == "Blue")
        {
            if(IsBlueUnlocked == false)
            {
                IsBlueUnlocked = true;
                Lock1.SetActive(false);
                Lock_1.SetActive(true);
            }
        }
        if (color == "Yellow")
        {
            if (IsYellowUnlocked == false)
            {
                IsYellowUnlocked = true;
                Lock2.SetActive(false);
                Lock_2.SetActive(true);
            }
        }
    }

    public void TriggerBlue()
    {
        SSfB.SetActive(true);
        SnSfB.SetActive(false);
        SSfN.SetActive(false);
        
        SelectedDragon = "Blue";
    }
    public void TriggerYellow()
    {
        SelectedDragon = "Yellow";
    }
    public void TriggerNormal()
    {
        SSfN.SetActive(true);
        SnSfN.SetActive(false);
        SSfB.SetActive(false);
        
        SelectedDragon = "Normal";
    }
}
