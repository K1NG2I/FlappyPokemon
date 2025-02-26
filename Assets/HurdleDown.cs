using UnityEngine;

public class HurdleDown : MonoBehaviour
{
    public GameObject Hurdle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame.level = 0;
        Hurdle.SetActive(false);
    }
    public static void ResetPosition(GameObject hurdle)
    {
        Vector2 v = hurdle.transform.position;
        v.x = 4f;
        v.y = -15f;
        hurdle.transform.position = v;
        StartGame.level = StartGame.Recentlevel;
    }
    // Update is called once per frame
    void Update()
    {

        if (FlyScript.IsGameRunning == true)
        {
            if (StartGame.level == 1)
            {
                transform.Translate((HurdleUp.speed == 0f ? 0.1f : HurdleUp.speed), 0, 0);
                if (transform.position.x <= -3.5f)
                {
                    
                    Vector2 v = transform.position;
                    v.x = 4f;
                    v.y = Random.Range(-16f, -18f);
                    transform.position = v;
                }
            }
          
            if (StartGame.level == 0)
            {
                Vector2 v = transform.position;
                v.x = 4f;
                v.y = -16.5f;
                transform.position = v;
                StartGame.level = StartGame.Recentlevel;
            }

        }
        else
        {
            Debug.Log("try this");
        }
    }
}
