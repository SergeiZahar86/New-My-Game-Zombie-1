using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text gameOverScore;
    static ScoreManager instance;
    public Text gameOverHighScore;
    public static ScoreManager Instance 
    {
        get
        {
            instance = FindObjectOfType<ScoreManager> ();
            return ScoreManager.instance;
        }
    }
    public void IncreaseScore()
    {
        // для gameOverScore
        score += 1;
        scoreText.text = "Score: " + score.ToString ();
        gameOverScore.text = "Score: " + score.ToString ();
        // для gameOverHighScore
        if (score > PlayerPrefs.GetInt ("HighScore", 0))
        {
            PlayerPrefs.SetInt ("HighScore", score);
        }
        gameOverHighScore.text = "High score: " + PlayerPrefs.GetInt ("HighScore", 0).ToString ();
    }
}
