using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public string retry;
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
        SceneManager.LoadScene(retry);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
