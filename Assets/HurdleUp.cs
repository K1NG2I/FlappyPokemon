using UnityEngine;

public class HurdleUp : MonoBehaviour
{
    public GameObject Hurdle;
    public static float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame.level = 0;
        Hurdle.SetActive(false);
    }
    
    public static void ResetPosition(GameObject hurdle)
    {

        Vector2 v = hurdle.transform.position;
        v.x = 0f;
        v.y = -5f;
        hurdle.transform.position = v;
        StartGame.level = StartGame.Recentlevel;
        
    }
   
    // Update is called once per frame
    void Update()
    {
        speed = FlyScript.score/100;   
        if (FlyScript.IsGameRunning == true)
        {

         
            if (StartGame.level == 1)
            {
                transform.Translate(-(speed == 0f ? 0.1f : speed), 0, 0);
                if (transform.position.x <= -3.5f)
                {

                    Vector2 v = transform.position;
                    v.x = 4f;
                    v.y = Random.Range(-8.5f, -9.5f);
                    transform.position = v;
                }
            }
          
            if (StartGame.level == 0)
            {
                
                Vector2 v = transform.position;
                v.x = 4f;
                v.y = -5f;
                transform.position = v;
                StartGame.level = StartGame.Recentlevel;
            }
            

        }
        
    }
}



