using UnityEngine;

public class ShiftLeft : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyScript.IsGameRunning == true)
        {


            if (StartGame.level == 1)
            {
                transform.Translate(-0.1f, 0, 0);
                if (transform.position.x <= -15f)
                {

                    Vector2 v = transform.position;
                    v.x = 14f;
                    v.y = -11.5f;
                    transform.position = v;
                }
            }
        }
       }
}
