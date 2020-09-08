using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    private static GameOverManager instance;
    public static GameOverManager Instance
    {
        get
        {
            instance = FindObjectOfType<GameOverManager> ();
            return GameOverManager.instance;
        }
    }
    public void GameOver ()
    {
        gameOverPanel.SetActive (true);
    }
    public void Restart ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}
