using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject magicNumber;

    public GameObject numberOne;
    public GameObject numberTwo;
    public GameObject numberThree;

    public GameObject answerOne;
    public GameObject answerTwo;
    public GameObject answerThree;
    public GameObject answerFour;
    public GameObject answerFive;

    public GameObject scoreDisplay;
    public int score;
    public Text highScore;
    public int countdownTime;
    public Text countdownDisplay;
    public string endScene;

    public string[] testBank;
    public string[] question;
    public int indexInBank;

    public String answer;

    IEnumerator CountdownToEnd()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        endGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        testBank = new string[] {"30,4,8,2", "48,3,2,8", "42,7,9,3", "12,4,2,6", "81,4,5,9", "39,4,9,3", "96,4,8,8", "10,2,3,2", "36,6,9,3", "77,7,4,7"};
        indexInBank = 0;
        question = testBank[indexInBank].Split(',');

        magicNumber = GameObject.Find("MediumMode/Panel/MagicNumber");

        numberOne = GameObject.Find("MediumMode/Panel/Number1");
        numberTwo = GameObject.Find("MediumMode/Panel/Number2");
        numberThree = GameObject.Find("MediumMode/Panel/Number3");

        answerOne = GameObject.Find("MediumMode/Panel/Answer1");
        answerTwo = GameObject.Find("MediumMode/Panel/Answer2");
        answerThree = GameObject.Find("MediumMode/Panel/Answer3");
        answerFour = GameObject.Find("MediumMode/Panel/Answer4");
        answerFive = GameObject.Find("MediumMode/Panel/Answer5");

        scoreDisplay = GameObject.Find("MediumMode/Panel/Score");
        score = PlayerPrefs.GetInt("CurrentScore");
        score = 0;
        PlayerPrefs.SetInt("CurrentScore", 0);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            highScore.text = 0.ToString();
            PlayerPrefs.SetInt("Highscore", 0);
        }

        answer = "";

        initializeCards(question[0], question[1], question[2], question[3]);

        StartCoroutine(CountdownToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (magicNumber.GetComponentInChildren<Text>().text.Length == 0) return;

        String ans = answerOne.GetComponentInChildren<Text>().text  + answerTwo.GetComponentInChildren<Text>().text + 
            answerThree.GetComponentInChildren<Text>().text + answerFour.GetComponentInChildren<Text>().text + 
            answerFive.GetComponentInChildren<Text>().text;

        answer = "";

        for (int i = 0; i < ans.Length; i++)
        {
            if (ans[i] == 'x')
            {
                answer += "*";
            } else if (ans[i] == '_')
            {
                answer += "-";
            } else
            {
                answer += ans[i];
            }
        }


        if (evaluate(answer, int.Parse(magicNumber.GetComponentInChildren<Text>().text)))
        {
            score++;
            PlayerPrefs.SetInt("CurrentScore", score);
            scoreDisplay.GetComponentInChildren<Text>().text = "Score: \n" + score;

            if (indexInBank < testBank.Length - 1)
            {
                indexInBank++;
            }

            question = testBank[indexInBank].Split(',');
            initializeCards(question[0], question[1], question[2], question[3]);
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene(endScene);
    }
    public void initializeCards(String magicNum, String numOne, String numTwo, String numThree)
    { 
        numberOne.GetComponent<CanvasGroup>().alpha = 1f;
        numberOne.GetComponent<Drag>().active = true;

        numberTwo.GetComponent<CanvasGroup>().alpha = 1f;
        numberTwo.GetComponent<Drag>().active = true;

        numberThree.GetComponent<CanvasGroup>().alpha = 1f;
        numberThree.GetComponent<Drag>().active = true;

        magicNumber.GetComponentInChildren<Text>().text = magicNum;
        numberOne.GetComponentInChildren<Text>().text = numOne;
        numberTwo.GetComponentInChildren<Text>().text = numTwo;
        numberThree.GetComponentInChildren<Text>().text = numThree;

        answerOne.GetComponentInChildren<Text>().text = "";
        answerTwo.GetComponentInChildren<Text>().text = "";
        answerThree.GetComponentInChildren<Text>().text = "";
        answerFour.GetComponentInChildren<Text>().text = "";
        answerFive.GetComponentInChildren<Text>().text = "";
    }

    private Boolean evaluate(String expression, int answer)
    {
        if (expression.Length != 5 || isOperator(expression, 0) || isOperator(expression, expression.Length - 1)){
            return false;
        } else
        {
            String expAnswer = "";
            for (int i = 0; i < expression.Length; i++)
            {
                if (i == 0)
                {
                    expAnswer += "(";
                }

                if (i == 3)
                {
                    expAnswer += ")";
                }

                expAnswer += expression[i];
            }
            try
            {
                return ((int)EvaluateString.Evaluate(expAnswer)) == answer;
            } catch (Exception e)
            {
                return false;
            }
            
        }
    }

    private Boolean isOperator(String expression, int index)
    {
        return expression[index] == '+' || expression[index] == '-' || expression[index] == 'x' || expression[index] == '/';
    }

    public void deactivateNumber(String name)
    {
        if (name == "Number1")
        {
            if (numberOne != null)
            {
                numberOne.SetActive(false);
            }

        }
        else if (name == "Number2")
        {
            if (numberTwo != null)
            {
                numberTwo.SetActive(false);
            }
        }
        else
        {
            if (numberThree != null)
            {
                numberThree.SetActive(false);
            }
        }
    }

    public void onReset()
    {
        initializeCards(question[0], question[1], question[2], question[3]);
    }

    public void onSkip()
    {
        score--;
        PlayerPrefs.SetInt("CurrentScore", score);
        scoreDisplay.GetComponentInChildren<Text>().text = "Score: \n" + score;

        if (indexInBank < testBank.Length - 1)
        {
            indexInBank++;
        }

        question = testBank[indexInBank].Split(',');
        initializeCards(question[0], question[1], question[2], question[3]);
    }
}
