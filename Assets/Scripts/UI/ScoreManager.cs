
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text gameOverScore;

    static ScoreManager instance;

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
        score += 1;
        scoreText.text = "Score: " + score.ToString ();
        gameOverScore.text = "Score: " + score.ToString ();
    }
}
