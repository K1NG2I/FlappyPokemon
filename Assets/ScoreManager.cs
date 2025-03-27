using UnityEngine;

public class ScoreManager
{
        private int _score;
        private int _highScore;
        public bool isHighScore;
        public int Score => _score;
        public int HighScore => _highScore;

        public ScoreManager()
        {
            _highScore = PlayerPrefs.GetInt("HighScore", 0);
        }

    public void SaveHighScore()
        {
            if (_score > _highScore)
            {
                _highScore = _score;
                PlayerPrefs.SetInt("HighScore", _highScore);
                PlayerPrefs.Save();
                isHighScore = true;
                
            }
        }
    public void IncrementScore()
    {
        _score++;
        SaveHighScore();
    }
    public void LoadHighScore()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void ResetScore()
    {
        _score = 0;
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        PlayerPrefs.Save();
        Debug.Log("Scores Reset to 0!");
    }
}
