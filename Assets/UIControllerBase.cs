using System.Collections.Generic;
using UnityEngine;

public abstract class UIControllerBase
{
    protected Dictionary<string, GameObject> _uiElements;

    protected UIControllerBase(Dictionary<string, GameObject> uiElements)
    {
        _uiElements = uiElements;
    }

    public abstract void ToggleUI(string uiElement);
}