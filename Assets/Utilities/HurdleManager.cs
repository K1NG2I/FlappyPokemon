using UnityEngine;

public class HurdleManager
{
    private GameObject _hurdleUp;
    private GameObject _hurdleDown;

    public HurdleManager(GameObject hurdleUp, GameObject hurdleDown)
    {
        _hurdleUp = hurdleUp;
        _hurdleDown = hurdleDown;
    }

    public void ActivateHurdles()
    {
        _hurdleUp.SetActive(true);
        _hurdleDown.SetActive(true);
    }

    public void DeactivateHurdles()
    {
        _hurdleUp.SetActive(false);
        _hurdleDown.SetActive(false);
    }
}
