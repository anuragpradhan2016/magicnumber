﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SinglePlayerScene;
    public string MultiPlayerScene;
    public string HowToPlayScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void singlePlayerScene()
    {
        SceneManager.LoadScene(SinglePlayerScene);
    }
    
    public void howToPlayScene()
    {
        SceneManager.LoadScene(HowToPlayScene);
    }
}
