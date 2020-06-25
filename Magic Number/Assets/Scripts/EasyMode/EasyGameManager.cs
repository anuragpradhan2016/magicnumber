using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasyGameManager : MonoBehaviour
{
    public GameObject magicNumber;

    public GameObject numberOne;
    public GameObject numberTwo;

    public GameObject answerOne;
    public GameObject answerTwo;
    public GameObject answerThree;
    public GameObject answerBackground;

    public GameObject scoreDisplay;

    public int divisionCounter;
    public int score;
    public Text highScore;
    public int countdownTime;
    public Text countdownDisplay;

    public string endScene;

    public string[] testBank;
    public string[] question;
    public int indexInBank;

    public String answer;

    public Color selected;
    public Color notSelected;

    IEnumerator CountdownToEnd()
    {
        while (countdownTime > 0)
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
        magicNumber = GameObject.Find("EasyMode/Panel/MagicNumber/");

        numberOne = GameObject.Find("EasyMode/Panel/Number1");
        numberTwo = GameObject.Find("EasyMode/Panel/Number2");

        answerOne = GameObject.Find("EasyMode/Panel/AnswerBackground/Answer1");
        answerTwo = GameObject.Find("EasyMode/Panel/AnswerBackground/Answer2");
        answerThree = GameObject.Find("EasyMode/Panel/AnswerBackground/Answer3");
        answerBackground = GameObject.Find("EasyMode/Panel/AnswerBackground");

        scoreDisplay = GameObject.Find("EasyMode/Panel/Score");
        score = PlayerPrefs.GetInt("CurrentScore");
        score = 0;

        PlayerPrefs.SetInt("CurrentScore", 0);
        highScore.text = PlayerPrefs.GetInt("EasyHighScore", 0).ToString();

        answerBackground.transform.SetAsFirstSibling();
        magicNumber.transform.SetAsFirstSibling();
        numberOne.transform.SetAsFirstSibling();
        numberTwo.transform.SetAsFirstSibling();
        GameObject.Find("EasyMode/Panel/Plus").transform.SetAsFirstSibling();
        GameObject.Find("EasyMode/Panel/Minus").transform.SetAsFirstSibling();
        GameObject.Find("EasyMode/Panel/Multiply").transform.SetAsFirstSibling();
        GameObject.Find("EasyMode/Panel/Divide").transform.SetAsFirstSibling();

        if (!PlayerPrefs.HasKey("EasyHighScore"))
        {
            highScore.text = 0.ToString();
            PlayerPrefs.SetInt("EasyHighscore", 0);
        }

        initializeCards();
        StartCoroutine(CountdownToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if (magicNumber.GetComponentInChildren<Text>().text.Length == 0) return;

        String ans = answerOne.GetComponentInChildren<Text>().text + answerTwo.GetComponentInChildren<Text>().text +
            answerThree.GetComponentInChildren<Text>().text;
        answer = "";

        for (int i = 0; i < ans.Length; i++)
        {
            if (ans[i] == 'x')
            {
                answer += "*";
            }
            else if (ans[i] == '_')
            {
                answer += "-";
            }
            else
            {
                answer += ans[i];
            }
        }


        if (evaluate(answer, int.Parse(magicNumber.GetComponentInChildren<Text>().text)))
        {
            score++;
            PlayerPrefs.SetInt("CurrentScore", score);
            scoreDisplay.GetComponentInChildren<Text>().text = "Score: \n" + score;

            initializeCards();
        }

        if (score > PlayerPrefs.GetInt("EasyHighScore", 0))
        {
            PlayerPrefs.SetInt("EasyHighScore", score);
            highScore.text = score.ToString();
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene(endScene);
    }
    public void initializeCards()
    {
        String magicNum, numOne, numTwo, numThree;
        EasyRandomizer rr = gameObject.GetComponent<EasyRandomizer>();

        magicNum = PlayerPrefs.GetInt("EasyTarget").ToString();
        numOne = PlayerPrefs.GetInt("EasyNumOne").ToString();
        numTwo = PlayerPrefs.GetInt("EasyNumTwo").ToString();

        numberOne.GetComponent<CanvasGroup>().alpha = 1f;
        numberOne.GetComponent<EasyDrag>().active = true;

        numberTwo.GetComponent<CanvasGroup>().alpha = 1f;
        numberTwo.GetComponent<EasyDrag>().active = true;

        magicNumber.GetComponentInChildren<Text>().text = magicNum;
        numberOne.GetComponentInChildren<Text>().text = numOne; ;
        numberTwo.GetComponentInChildren<Text>().text = numTwo;

        answerOne.GetComponentInChildren<Text>().text = "";
        answerTwo.GetComponentInChildren<Text>().text = "";
        answerThree.GetComponentInChildren<Text>().text = "";
        rr.Genproblem();
    }

    private Boolean evaluate(String expression, int answer)
    {
        if (expression.Length != 3 || isOperator(expression, 0) || isOperator(expression, expression.Length - 1))
        {
            return false;
        }
        else
        {
            try
            {
                return ((int)EvaluateString.Evaluate(expression)) == answer;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }

    private Boolean isOperator(String expression, int index)
    {
        return expression[index] == '+' || expression[index] == '-' || expression[index] == 'x' || expression[index] == '/';
    }
}
