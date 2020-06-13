using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

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

    public int[] testResults;

    public String answer;

    // Start is called before the first frame update
    void Start()
    {
        testResults = new int[] { 30, 4, 8, 2 };

        magicNumber = GameObject.Find("Canvas/Panel/MagicNumber");

        numberOne = GameObject.Find("Canvas/Panel/Number1");
        numberTwo = GameObject.Find("Canvas/Panel/Number2");
        numberThree = GameObject.Find("Canvas/Panel/Number3");

        answerOne = GameObject.Find("Canvas/Panel/Answer1");
        answerTwo = GameObject.Find("Canvas/Panel/Answer2");
        answerThree = GameObject.Find("Canvas/Panel/Answer3");
        answerFour = GameObject.Find("Canvas/Panel/Answer4");
        answerFive = GameObject.Find("Canvas/Panel/Answer5");

        answer = "";

        initializeCards(testResults[0].ToString(), testResults[1].ToString(), testResults[2].ToString(), testResults[3].ToString());
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
            initializeCards(testResults[0].ToString(), testResults[1].ToString(), testResults[2].ToString(), testResults[3].ToString());
        }
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
            try
            {
                return ((int)EvaluateString.Evaluate(expression)) == answer;
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
        initializeCards(testResults[0].ToString(), testResults[1].ToString(), testResults[2].ToString(), testResults[3].ToString());
    }
}
