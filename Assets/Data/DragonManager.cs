using System.Collections.Generic;
using UnityEngine;

public class DragonManager
{
    private Dictionary<string, GameObject> _dragons;
    public GameObject ActiveDragon { get; private set; }

    public DragonManager(GameObject normal, GameObject blue, GameObject yellow)
    {
        _dragons = new Dictionary<string, GameObject>
        {
            { "Dragon_Starter", normal },
            { "Dragon_Ice_Main", blue },
            { "Dragon_Yellow_Main", yellow }
        };
    }

    public void SetActiveDragon(string dragonType)
    {
        foreach (var dragon in _dragons)
        {
            //Polymorphism
            if (dragonType == dragon.Key)
            {
                dragon.Value.SetActive(true);
                ActiveDragon = dragon.Value;
            }
            else
            {
                dragon.Value.SetActive(false);
            }
        }
    }
}
