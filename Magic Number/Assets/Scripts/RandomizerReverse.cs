/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerReverse : MonoBehaviour
{
    public int targetNumber;
    public int targetBuilder;
    public int testOperator;
    public int turnsTillDivide;
    public int testNumber;
    public int operatorOne;
    public int operatorTwo;
    public int numberOne;
    public int numberTwo;
    public int numberThree;
    public int failCount;

    public float targetTest;
    public float numberTest;

    public Boolean completed;

    public void GenerateNum()
    {
        targetNumber = Random.Range(10, 101);
        targetTest = targetNumber;
        targetBuilder = targetNumber;
        turnsTillDivide = PlayerPrefs.GetInt("Divide");

        //for operators, 1 = +, 2 = -, 3 = x, 4 = /
        if (turnsTillDivide > 0)
        {
            testOperator = Random.Range(1, 5);
            if(testOperator == 1)
            {
                numberOne = Random.Range(2, 10);
                operatorOne = 2;
                targetBuilder = targetNumber + numberOne;
            }
            else if (testOperator == 2)
            {
                numberOne = Random.Range(2, 10);
                operatorOne = 1;
                targetBuilder = targetNumber + numberOne;
            }
            else if (testOperator == 3)
            {
                numberOne = Random.Range(2, 10);
                operatorOne = 4;
                targetBuilder = targetNumber * numberOne;          
            }
            else
            {

            }

            turnsTillDivide--;
            PlayerPrefs.SetInt("Divide", turnsTillDivide);
        }
        else
        {
            ForceDivide();
        }
    }

    public void ForceDivide()
    {
        turnsTillDivide = Random.Range(2, 6);
        PlayerPrefs.SetInt("Divide", turnsTillDivide);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Divide"))
        {
            PlayerPrefs.SetInt("Divide", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/