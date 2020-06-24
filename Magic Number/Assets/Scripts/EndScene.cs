using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public string retrym;
    public string retrye;
    public string retryh;
    public string mainMenu;
    public Text endScore;
    public Text endHighScore;
    // Start is called before the first frame update
    void Start()
    {
        endHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        endScore.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry()
    {
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            SceneManager.LoadScene(retrye);
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            SceneManager.LoadScene(retrym);
        }
        else
        {
            SceneManager.LoadScene(retryh);
        }
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
