using UnityEngine;
using UnityEngine.UI;

public class FlyScript : MonoBehaviour
{
    public static int score;
    public static int newscore;
    public static int hiscore;
    public static bool sethighscore;
    public static bool IsGameRunning;
    public static bool IsGameStarted;
    public Text ScoreText;
    public Text YourScore;
    public Text BestScore,BestScore2;
    public GameObject GameBackGround;
    public GameObject GameBackGround0;
    public GameObject GameOverScreen;
    public GameObject ScoreBoard;
    public GameObject NewScore;
    public Text BestScore1;
    public GameObject MainScore;
    public GameObject Hurdleup;
    public GameObject Hurdledown;
    public GameObject Base;
    public GameObject Dragon_Normal;
    public bool ChangeLevel;
    public static bool IsGameStopped;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsGameStopped = false;
        GameBackGround.SetActive(false);
        GameBackGround0.SetActive(false);
        ScoreBoard.SetActive(false);
        Base.SetActive(false);
        newscore = 0;
        hiscore = PlayerPrefs.GetInt("HighScore", 0); ;
        sethighscore = false;
        IsGameRunning = false;
        IsGameStarted = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Debug.Log(transform.position.y);

    }
    // Update is called once per frame
    void Update()
    {
        ChecHighScore();
        checklevel();
        
        if (Input.GetMouseButtonDown(0))
        {
            NewScore.SetActive(false);

            if (IsGameStarted == true)
            {
                Debug.Log("The check level has changed");
                ScoreBoard.SetActive(true);
                if (IsGameRunning == false)
                {
                    IsGameRunning = true;
                    score = 0;
                    ScoreText.text = "Score " + score;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    GameBackGround.SetActive(true);
                    GameBackGround0.SetActive(true);
                    Hurdleup.SetActive(true);
                    Hurdledown.SetActive(true);
                    Base.SetActive(true);
                    MainScore.SetActive(false);
                    Debug.Log(StartGame.level);
                }
                transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
            }
        }
        
    }
    public void checklevel()
    {
        if(ChangeLevel == true)
        {
            StartGame.level = 0;
            ChangeLevel = false;
        }
    }
    public void ChecHighScore()
    {
        if (sethighscore == true) {
            GameOverScreen.SetActive(true);   
            sethighscore = false;
     
            ChangeLevel = false;
      
        }
    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name.StartsWith("HurdleUp") || collision.collider.gameObject.name.StartsWith("HurdleDown") || collision.collider.gameObject.name.StartsWith("Base") || collision.collider.gameObject.name.StartsWith("TopBase")) {
            gameOver();
        }
    }


    public void gameOver()
    {
        IsGameRunning = false;
        IsGameStarted = false;
        ChangeLevel = true;
        HurdleUp.ResetPosition(Hurdleup);
        HurdleDown.ResetPosition(Hurdledown);
        Hurdleup.SetActive(false);
        Hurdledown.SetActive(false);
        Base.SetActive(false);
        ScoreBoard.SetActive(false);
        GameBackGround.SetActive(false);
        GameBackGround0.SetActive(false);
        MainScore.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        Vector2 v = transform.position;
        v.y = -13f;
        transform.position = v;
        YourScore.text = "Your Score : " + score / 3;
        BestScore.text = "Best Score : " + PlayerPrefs.GetInt("HighScore");
        BestScore2.text = "" + newscore;
        if (PlayerPrefs.GetInt("HighScore") <= score / 3)
        {
            NewScore.SetActive(true);
            sethighscore = true;
            BestScore1.text = "Best Score : " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            GameOverScreen.SetActive(true);
        }
        Dragon_Normal.SetActive(false);
        IsGameStopped = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        score++;
        ScoreText.text = "Score " + score/3;
        if (newscore <= score/3)
        {
            newscore = score / 3;
            PlayerPrefs.SetInt("HighScore", score/3);
            PlayerPrefs.Save();
        }
    }
}
