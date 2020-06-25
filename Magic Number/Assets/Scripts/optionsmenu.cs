using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class optionsmenu : MonoBehaviour
{
    public Text solve;
    public string tutorial;
    // Start is called before the first frame update

    public void setSolve()
    {
        if (PlayerPrefs.GetInt("Solve") == 0)
        {
            PlayerPrefs.SetInt("Solve", 1);
            solve.text = "Right";
        }
        else
        {
            PlayerPrefs.SetInt("Solve", 0);
            solve.text = "Left";
        }
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("Solve"))
        {
            PlayerPrefs.SetInt("Solve", 0);
        }
        if (PlayerPrefs.GetInt("Solve") == 0)
        {
            solve.text = "Left";
        }
        else
        {
            solve.text = "Right";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void replayTutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void clearScores()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("HardHighscore", 0);
        PlayerPrefs.SetInt("EasyHighScore", 0);
    }
}
