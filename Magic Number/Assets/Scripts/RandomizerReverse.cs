using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizerReverse : MonoBehaviour
{
    public int targetNumber;
    public int targetBuilder;
    public int targetBuilder2;
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
    public float buildTest;

    public int completed;

    public Text numOne;
    public Text numTwo;
    public Text numThree;
    public Text opOne;
    public Text opTwo;
    public Text NumTarg;

    IEnumerator GenerateNum()
    {
        turnsTillDivide = PlayerPrefs.GetInt("Divide");
        if (turnsTillDivide < 0)
        {
            turnsTillDivide = UnityEngine.Random.Range(2, 6);
            PlayerPrefs.SetInt("Divide", turnsTillDivide);
        }
        if(turnsTillDivide != 0)
        {
            completed = 0;
            while (completed == 0)
            {
                targetNumber = UnityEngine.Random.Range(10, 101);
                testNumber = UnityEngine.Random.Range(2, 10);
                testOperator = UnityEngine.Random.Range(1, 6);
                numberOne = 10;
                numberTwo = 10;
                numberThree = 10;
                failCount = 0;

                //Operators correspond as following, 1 = +, 2 = -, 3 = *, 4 = /
                targetBuilder = 10;
                while (numberOne == 10 && failCount <= 4)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder = targetNumber - testNumber;
                        if (targetBuilder < 82 && targetBuilder2 > 1)
                        {
                            numberOne = testNumber;
                            operatorOne = 1;
                        }
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else if (testOperator == 2 || testOperator == 5)
                    {
                        testOperator = 2;
                        targetBuilder = targetNumber + testNumber;
                        if (targetBuilder < 82 && targetBuilder2 > 1)
                        {
                            numberOne = testNumber;
                            operatorOne = 2;
                        }
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else if (testOperator == 3)
                    {
                        targetTest = targetNumber;
                        numberTest = testNumber;
                        buildTest = targetTest / numberTest;
                        targetBuilder = targetNumber / testNumber;
                        if (buildTest != targetBuilder)
                        {
                            targetBuilder = 10;
                            numberOne = 10;
                            testOperator++;
                            failCount++;
                        }
                        else if (targetBuilder < 82 && buildTest == targetBuilder && targetBuilder2 > 1)
                        {
                            numberOne = testNumber;
                            operatorOne = 3;
                        }
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else
                    {
                        targetBuilder = targetNumber * testNumber;
                        if (targetBuilder < 82 && targetBuilder2 > 1)
                        {
                            numberOne = testNumber;
                            operatorOne = 4;
                        }
                        else
                        {
                            testOperator = 1;
                            failCount++;
                        }
                    }
                    yield return null;
                }
                    testNumber = UnityEngine.Random.Range(1, 10);
                    testOperator = UnityEngine.Random.Range(1, 6);
                    failCount = 0;
                    targetBuilder2 = 10;
                while (numberTwo == 10 && failCount < 4 && numberOne < 10)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder2 = targetBuilder - testNumber;
                        if (targetBuilder2 < 10 && targetBuilder2 > 1)
                        {
                            numberTwo = testNumber;
                            numberThree = targetBuilder2;
                            operatorTwo = 1;
                            completed = 1;
                        }
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else if (testOperator == 2 || testOperator == 5)
                    {
                        testOperator = 2;
                        targetBuilder2 = targetBuilder + testNumber;
                        if (targetBuilder2 < 10 && targetBuilder2 > 1)
                        {
                            numberTwo = testNumber;
                            numberThree = targetBuilder2;
                            operatorTwo = 2;
                            completed = 1;
                        }
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else if (testOperator == 3)
                    {
                        targetBuilder2 = targetBuilder / testNumber;
                        targetTest = targetBuilder;
                        numberTest = testNumber;
                        buildTest = targetTest / numberTest;
                        if (targetBuilder2 <10 && buildTest == targetBuilder2 && targetBuilder2 > 1)
                        {
                            numberTwo = testNumber;
                            numberThree = targetBuilder2;
                            operatorTwo = 3;
                            completed = 1;
                        }    
                        else
                        {
                            testOperator++;
                            failCount++;
                        }
                    }
                    else
                    {
                        targetBuilder2 = targetBuilder * testNumber;
                        if (targetBuilder2 < 10 && targetBuilder2 > 1)
                        {
                            numberTwo = testNumber;
                            numberThree = targetBuilder2;
                            operatorTwo = 4;
                            completed = 1;
                        }
                        else
                        {
                            testOperator = 1;
                            failCount++;
                        }
                    }
                    yield return null;
                }
                yield return null;

            }
            if ((operatorOne != 4 && operatorTwo !=4))
            {
                turnsTillDivide--;
                PlayerPrefs.SetInt("Divide", turnsTillDivide);
            }
            if (operatorOne == 4 || operatorTwo == 4)
            {
                turnsTillDivide = UnityEngine.Random.Range(2, 6);
                PlayerPrefs.SetInt("Divide", turnsTillDivide);
            }
            numOne.text = numberOne.ToString();
            numTwo.text = numberTwo.ToString();
            numThree.text = numberThree.ToString();
            if (operatorOne == 1)
            {
                opOne.text = "+";
            }
            else if (operatorOne == 2)
            {
                opOne.text = "-";
            }
            else if (operatorOne == 3)
            {
                opOne.text = "x";
            }
            else
            {
                opOne.text = "/";
            }
            if (operatorTwo == 1)
            {
                opTwo.text = "+";
            }
            else if (operatorTwo == 2)
            {
                opTwo.text = "-";
            }
            else if (operatorTwo == 3)
            {
                opTwo.text = "x";
            }
            else
            {
                opTwo.text = "/";
            }
            NumTarg.text = targetNumber.ToString();
            PlayerPrefs.SetInt("NumberOne", numberOne);
            PlayerPrefs.SetInt("NumberTwo", numberTwo);
            PlayerPrefs.SetInt("NumberThree", numberThree);
            PlayerPrefs.SetInt("OperatorOne", operatorOne);
            PlayerPrefs.SetInt("OperatorTwo", operatorTwo);
            PlayerPrefs.SetInt("TargetNumber", targetNumber);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            ForceDivide();
        }
    }

    public void ForceDivide()
    {
        turnsTillDivide = UnityEngine.Random.Range(2, 6);
        PlayerPrefs.SetInt("Divide", turnsTillDivide);
    }

    public void GenButton()
    {
        StartCoroutine(GenerateNum());
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Divide"))
        {
            PlayerPrefs.SetInt("Divide", 0);
        }
        if (!PlayerPrefs.HasKey("NumberOne"))
        {
            PlayerPrefs.SetInt("NumberOne", 0);
        }
        if (!PlayerPrefs.HasKey("NumberTwo"))
        {
            PlayerPrefs.SetInt("NumberTwo", 0);
        }
        if (!PlayerPrefs.HasKey("NumberThree"))
        {
            PlayerPrefs.SetInt("NumberThree", 0);
        }
        if (!PlayerPrefs.HasKey("OperatorOne"))
        {
            PlayerPrefs.SetInt("OperatorOne", 0);
        }
        if (!PlayerPrefs.HasKey("OperatorTwo"))
        {
            PlayerPrefs.SetInt("OperatorTwo", 0);
        }
        if (!PlayerPrefs.HasKey("TargetNumber"))
        {
            PlayerPrefs.SetInt("TargetNumber", 0);
        }
        StartCoroutine(GenerateNum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
