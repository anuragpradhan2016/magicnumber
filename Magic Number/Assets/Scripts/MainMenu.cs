using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string singlePlayerScene;
    public string multiPlayerScene;
    public string howToPlayScene;
    public string easyModeScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SinglePlayerScene()
    {
        SceneManager.LoadScene(singlePlayerScene);
    }
    
    public void HowToPlayScene()
    {
        SceneManager.LoadScene(howToPlayScene);
    }


    public void EasyModeScene()
    {
        SceneManager.LoadScene(easyModeScene);
    }
}
