using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelect : MonoBehaviour
{
    public string easy;
    public string medium;
    public string hard;
    public string main;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("Mode"))
        {
            PlayerPrefs.SetInt("Mode", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void easyMode()
    {
        SceneManager.LoadScene(easy);
        PlayerPrefs.SetInt("Mode", 1);
    }

    public void mediumMode()
    {
        SceneManager.LoadScene(medium);
        PlayerPrefs.SetInt("Mode", 2);
    }

    public void hardMode()
    {
        SceneManager.LoadScene(hard);
        PlayerPrefs.SetInt("Mode", 3);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(main);
    }
}
