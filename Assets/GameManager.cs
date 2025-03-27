using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private ScoreManager _scoreManager;
    private PlayerManager _playerManager;
    private HurdleManager _hurdleManager;
    private StartGame _startGame;
    private DragonManager _dragonManager;

    private bool _isGameRunning;
    private bool _isGameStarted;

    public GameObject NewScore; 
    public GameObject Player;
    private Rigidbody2D _rb;
    public UIController UIController;
    public Text ScoreText, HighScoreText, YourScore, BestScore;
    public GameObject GameOverScreen, ScoreBoard, MainScore;
    public Button RestartButton;

    public GameObject HurdleUp, HurdleDown, Base;

    public GameObject Dragon_Normal, Dragon_Blue, Dragon_Yellow;

    public bool IsGameRunning => _isGameRunning;
    public bool IsGameStarted => _isGameStarted;
    public int Score => _scoreManager.Score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _scoreManager = new ScoreManager();
        _playerManager = new PlayerManager(Player);
        _hurdleManager = new HurdleManager(HurdleUp, HurdleDown);
        _dragonManager = new DragonManager(Dragon_Normal, Dragon_Blue, Dragon_Yellow);
        _startGame = new StartGame(_dragonManager);
    }

    private void Start()
    {
        _rb = Player.GetComponent<Rigidbody2D>();
        _scoreManager.LoadHighScore();
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGameStarted == true)
        {
            _playerManager.Jump();
        }

        if (_isGameStarted)
        {
            if (IsColliding(Player, Base))
            {
                StopGame();
            }

            if (IsColliding(Player, HurdleUp) || IsColliding(Player, HurdleDown))
            {
                StopGame();
            }

            if (Player.transform.position.x > HurdleUp.transform.position.x && !HurdleUp.GetComponent<HurdleController>().isPassed)
            {
                HurdleUp.GetComponent<HurdleController>().isPassed = true;
                IncrementScore();
            }

           
            
        }
    }

    private bool IsColliding(GameObject obj1, GameObject obj2)
    {
        Vector2 pos1 = obj1.transform.position;
        Vector2 pos2 = obj2.transform.position;
        Vector2 size1 = obj1.GetComponent<SpriteRenderer>().bounds.size;
        Vector2 size2 = obj2.GetComponent<SpriteRenderer>().bounds.size;

        bool isOverlappingX = Mathf.Abs(pos1.x - pos2.x) < (size1.x / 2 + size2.x / 2);
        bool isOverlappingY = Mathf.Abs(pos1.y - pos2.y) < (size1.y / 2 + size2.y / 2);

        return isOverlappingX && isOverlappingY;
    }
    private void IncrementScore()
    {
        _scoreManager.IncrementScore(); 
        ScoreText.text = "Score " + _scoreManager.Score;
    }
    public void StartGame()
    {
        
        _isGameStarted = true;
        _isGameRunning = true;
        _rb.gravityScale = 1;
        ScoreBoard.SetActive(true);
        MainScore.SetActive(false);
        UIController.ToggleUIOff("LandingPage");
        UIController.ToggleUIOn("MainFrame");
        _dragonManager.SetActiveDragon("Dragon_Ice_Main");
        _hurdleManager.ActivateHurdles();
    }

    public void StopGame()
    {
        _isGameRunning = false;
        _isGameStarted = false;
        _rb.gravityScale = 0;
        Player.transform.position = new Vector2(Player.transform.position.x, -13f);
        UIController.HideAllUI("GameOver");
        StartCoroutine(EnableRestartButtonAfterDelay(1));
        BestScore.text = "Best Score: " + _scoreManager.HighScore;
        YourScore.text = "Your Score: " + _scoreManager.Score;
        HighScoreText.text = "High Score" + _scoreManager.HighScore;
        MainScore.SetActive(true);
        if(_scoreManager.isHighScore == true)
        {
            UIController.HideAllUI("NewScore");
        }
    }

   

    public void RestartGame()
    {
        ResetGame();
        StartGame();
    }

    public void ResetGame()
    {
        UIController.HideAllUI("LandingPage");
        _scoreManager.ResetScore();
        _rb.gravityScale = 0;
        ScoreBoard.SetActive(false);
        MainScore.SetActive(true);
        _hurdleManager.DeactivateHurdles();
        if (NewScore != null)
        {
            NewScore.SetActive(false);
        }
    }

    private IEnumerator EnableRestartButtonAfterDelay(int delay)
    {
        RestartButton.interactable = false;
        yield return new WaitForSeconds(delay);
        RestartButton.interactable = true;
    }

    public void ChooseDragon(string dragonType)
    {
        _startGame.SelectDragon(dragonType);
    }
}
