using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public bool IsBlueUnlocked;
    public bool IsYellowUnlocked;
    public static string SelectedDragon;
    public GameObject Lock1,Lock2,Lock_1, Lock_2;
    public GameObject SSfB, SnSfB, SSfN, SnSfN;
    void Update()
    {
        if (PlayerPrefs.GetInt("HighScore") >= 10)
        {
            Unlock("Blue");
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
