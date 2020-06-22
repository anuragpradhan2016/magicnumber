using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counttostart : MonoBehaviour
{
    public int countInTime;
    public Text countInDisplay;

    public string sceneEasy;
    public string sceneMed;
    public string sceneHard;

    IEnumerator countIn()
    {
        while (countInTime > 0)
        {
            countInDisplay.text = countInTime.ToString();
            yield return new WaitForSeconds(1f);
            countInTime--;
        }
        countInDisplay.text = "Go!";
        yield return new WaitForSeconds(1f);
        if (PlayerPrefs.GetInt("Mode") == 1)
        {
            SceneManager.LoadScene(sceneEasy);
        }
        else if (PlayerPrefs.GetInt("Mode") == 2)
        {
            SceneManager.LoadScene(sceneMed);
        }
        else
        {
            SceneManager.LoadScene(sceneHard);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        countInTime = 3;
        StartCoroutine(countIn());
        RandomizerReverse rr = gameObject.GetComponent<RandomizerReverse>();
        rr.GenButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
