using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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


    void Start()
    {
        
    }

    
    void Update()
    {
        
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
