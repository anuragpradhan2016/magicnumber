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
    public GameObject answerBackground;

    public GameObject scoreDisplay;

    public GameObject noParentheses;
    public GameObject leftParentheses;
    public GameObject rightParentheses;

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
    public int parenthesesOption; // 0 -> Left, 1 -> None, 2 -> Right

    public Color selected;
    public Color notSelected;

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
        if (!PlayerPrefs.HasKey("ForceDiv"))
        {
            PlayerPrefs.SetInt("ForceDiv", 0);
        }
        if (PlayerPrefs.GetInt("ForceDiv") == 0)
        {
            StartCoroutine(RandomProblem.generateProblem(2, 10, PlayerPrefs.GetInt("ForceDiv") == 0));
            divisionCounter = UnityEngine.Random.Range(2, 6);
            PlayerPrefs.SetInt("ForceDiv", divisionCounter);
        }
        else
        {
            StartCoroutine(RandomProblem.generateProblem(2, 10, false));
            divisionCounter = PlayerPrefs.GetInt("ForceDiv");
        }
        divisionCounter--;
        PlayerPrefs.SetInt("ForceDiv", divisionCounter);
        question = RandomProblem.randomProblem.Split(',');

        magicNumber = GameObject.Find("MediumMode/Panel/MagicNumber");

        numberOne = GameObject.Find("MediumMode/Panel/Number1");
        numberTwo = GameObject.Find("MediumMode/Panel/Number2");
        numberThree = GameObject.Find("MediumMode/Panel/Number3");

        answerOne = GameObject.Find("MediumMode/Panel/AnswerBackground/Answer1");
        answerTwo = GameObject.Find("MediumMode/Panel/AnswerBackground/Answer2");
        answerThree = GameObject.Find("MediumMode/Panel/AnswerBackground/Answer3");
        answerFour = GameObject.Find("MediumMode/Panel/AnswerBackground/Answer4");
        answerFive = GameObject.Find("MediumMode/Panel/AnswerBackground/Answer5");
        answerBackground = GameObject.Find("MediumMode/Panel/AnswerBackground");

        scoreDisplay = GameObject.Find("MediumMode/Panel/Score");
        score = PlayerPrefs.GetInt("CurrentScore");
        score = 0;

        PlayerPrefs.SetInt("CurrentScore", 0);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        parenthesesOption = 1;
        selected = noParentheses.GetComponent<Image>().color;
        notSelected = leftParentheses.GetComponent<Image>().color;

        answerBackground.transform.SetAsFirstSibling();
        magicNumber.transform.SetAsFirstSibling();
        noParentheses.transform.SetAsFirstSibling();
        leftParentheses.transform.SetAsFirstSibling();
        rightParentheses.transform.SetAsFirstSibling();
        GameObject.Find("MediumMode/Panel/Parenthesis").transform.SetAsFirstSibling();
        scoreDisplay.transform.SetAsFirstSibling();
        highScore.transform.SetAsFirstSibling();
        countdownDisplay.transform.SetAsFirstSibling();
        numberOne.transform.SetAsFirstSibling();
        numberTwo.transform.SetAsFirstSibling();
        numberThree.transform.SetAsFirstSibling();
        GameObject.Find("MediumMode/Panel/Plus").transform.SetAsFirstSibling();
        GameObject.Find("MediumMode/Panel/Minus").transform.SetAsFirstSibling();
        GameObject.Find("MediumMode/Panel/Multiply").transform.SetAsFirstSibling();
        GameObject.Find("MediumMode/Panel/Divide").transform.SetAsFirstSibling();
 

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
            countdownTime += 5;
            score++;
            PlayerPrefs.SetInt("CurrentScore", score);
            scoreDisplay.GetComponentInChildren<Text>().text = "Score: \n" + score;

            if (PlayerPrefs.GetInt("ForceDiv") == 0)
            {
                StartCoroutine(RandomProblem.generateProblem(2, 10, PlayerPrefs.GetInt("ForceDiv") == 0));
                divisionCounter = UnityEngine.Random.Range(2, 6);
                PlayerPrefs.SetInt("ForceDiv", divisionCounter);
            }
            else
            {
                StartCoroutine(RandomProblem.generateProblem(2, 10, false));
                divisionCounter = PlayerPrefs.GetInt("ForceDiv");
            }
            divisionCounter--;
            PlayerPrefs.SetInt("ForceDiv", divisionCounter);
            question = RandomProblem.randomProblem.Split(',');
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
                if (parenthesesOption == 0 && i == 0)
                {
                    expAnswer += "(";
                }

                if (parenthesesOption == 0 && i == 3)
                {
                    expAnswer += ")";
                } 
                
                if (parenthesesOption == 2 && i == 2)
                {
                    expAnswer += "(";
                } 

                expAnswer += expression[i];

                if (parenthesesOption == 2 && i == 4)
                {
                    expAnswer += ")";
                }
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

    public void noParenthesesAction()
    {
        parenthesesOption = 1;
        noParentheses.GetComponent<Image>().color = selected;
        leftParentheses.GetComponent<Image>().color = notSelected;
        rightParentheses.GetComponent<Image>().color = notSelected;
    }

    public void leftParenthesesAction()
    {
        parenthesesOption = 0;
        noParentheses.GetComponent<Image>().color = notSelected;
        leftParentheses.GetComponent<Image>().color = selected;
        rightParentheses.GetComponent<Image>().color = notSelected;
    }

    public void rightParenthesesAction()
    {
        parenthesesOption = 2;
        noParentheses.GetComponent<Image>().color = notSelected;
        leftParentheses.GetComponent<Image>().color = notSelected;
        rightParentheses.GetComponent<Image>().color = selected;
    }

}
