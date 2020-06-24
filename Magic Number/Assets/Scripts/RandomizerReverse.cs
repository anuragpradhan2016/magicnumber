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
    public int RnumberOne;
    public int RnumberTwo;
    public int RnumberThree;
    public int failCount;

    public float targetTest;
    public float numberTest;
    public float buildTest;

    public int completed;
    public int divDec;

   /* public Text numOne;
    public Text numTwo;
    public Text numThree;
    public Text opOne;
    public Text opTwo;
    public Text numTarg; */

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
                RnumberOne = 10;
                RnumberTwo = 10;
                RnumberThree = 10;
                failCount = 0;

                //Operators correspond as following, 1 = +, 2 = -, 3 = *, 4 = /
                targetBuilder = 10;
                while (RnumberOne == 10 && failCount <= 4)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder = targetNumber - testNumber;
                        if (targetBuilder < 82 && targetBuilder2 > 1)
                        {
                            RnumberOne = testNumber;
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
                            RnumberOne = testNumber;
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
                            RnumberOne = 10;
                            testOperator++;
                            failCount++;
                        }
                        else if (targetBuilder < 82 && buildTest == targetBuilder && targetBuilder2 > 1)
                        {
                            RnumberOne = testNumber;
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
                            RnumberOne = testNumber;
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
                    testNumber = UnityEngine.Random.Range(2, 10);
                    testOperator = UnityEngine.Random.Range(1, 6);
                    failCount = 0;
                    targetBuilder2 = 10;
                while (RnumberTwo == 10 && failCount < 4 && RnumberOne < 10 && PlayerPrefs.GetInt("Mode") != 1)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder2 = targetBuilder - testNumber;
                        if (targetBuilder2 < 10 && targetBuilder2 > 1)
                        {
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
            /*numOne.text = RnumberOne.ToString();
            numTwo.text = RnumberTwo.ToString();
            numThree.text = RnumberThree.ToString();
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
            numTarg.text = targetNumber.ToString();*/

            /*
             PlayerPrefs.SetInt("OperatorOne", operatorOne);
             PlayerPrefs.SetInt("OperatorTwo", operatorTwo);
            */


            PlayerPrefs.SetInt("NumberOne", RnumberOne);
            PlayerPrefs.SetInt("NumberTwo", RnumberTwo);
            PlayerPrefs.SetInt("NumberThree", RnumberThree);
            PlayerPrefs.SetInt("TargetNumber", targetNumber);


            yield return new WaitForSeconds(1f);
        }
        else
        {
            StartCoroutine(ForceDivide());
        }
    }

    IEnumerator ForceDivide()
    {
        completed = 0;
        while (completed == 0)
        {
            divDec = UnityEngine.Random.Range(1, 3);
            if (divDec == 1)
            {
                targetNumber = UnityEngine.Random.Range(2, 101);
                testNumber = UnityEngine.Random.Range(2, 10);
                RnumberOne = 10;
                RnumberTwo = 10;
                RnumberThree = 10;
                failCount = 0;
                operatorOne = 4;

                while (RnumberOne == 10 && failCount < 4)
                {
                    targetBuilder = targetNumber * testNumber;
                    if (targetBuilder > 1 && testNumber > 1)
                    {
                        RnumberOne = testNumber;
                    }
                    else
                    {
                        failCount++;
                    }                      
                    yield return null;
                }

                testNumber = UnityEngine.Random.Range(2, 10);
                testOperator = UnityEngine.Random.Range(1, 6);
                failCount = 0;
                while (RnumberTwo == 10 && failCount < 4 && RnumberOne < 10 && PlayerPrefs.GetInt("Mode") != 1)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder2 = targetBuilder - testNumber;
                        if (targetBuilder2 < 10 && targetBuilder2 > 1)
                        {
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                        if (targetBuilder2 < 10 && buildTest == targetBuilder2 && targetBuilder2 > 1)
                        {
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
                            RnumberTwo = testNumber;
                            RnumberThree = targetBuilder2;
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
            }
            else
            {
                targetNumber = UnityEngine.Random.Range(10, 101);
                testNumber = UnityEngine.Random.Range(2, 10);
                testOperator = UnityEngine.Random.Range(1, 6);
                RnumberOne = 10;
                RnumberTwo = 10;
                RnumberThree = 10;
                failCount = 0;
                operatorTwo = 4;

                while (RnumberOne == 10 && failCount <= 4)
                {
                    if (testOperator == 1)
                    {
                        targetBuilder = targetNumber - testNumber;
                        if (targetBuilder < 82 && targetBuilder2 > 1)
                        {
                            RnumberOne = testNumber;
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
                            RnumberOne = testNumber;
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
                            RnumberOne = 10;
                            testOperator++;
                            failCount++;
                        }
                        else if (targetBuilder < 82 && buildTest == targetBuilder && targetBuilder2 > 1)
                        {
                            RnumberOne = testNumber;
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
                            RnumberOne = testNumber;                           
                        }
                        else
                        {
                            testOperator = 1;
                            failCount++;
                        }
                    }
                    yield return null;
                }
                testNumber = UnityEngine.Random.Range(2, 10);
                failCount = 0;
                targetBuilder2 = 10;
                while (RnumberTwo == 10 && failCount < 4 && PlayerPrefs.GetInt("Mode") != 1)
                {
                    targetBuilder2 = targetBuilder * testNumber;
                    if (targetBuilder2 > 1 && testNumber > 1 && targetBuilder2 < 10 && testNumber < 10)
                    {
                        RnumberTwo = testNumber;
                        RnumberThree = targetBuilder2;
                        operatorTwo = 4;
                        completed = 1;
                    }
                    else
                    {
                        failCount++;
                    }
                    yield return null;
                }
            }
            yield return null;
        }
        /*numOne.text = RnumberOne.ToString();
        numTwo.text = RnumberTwo.ToString();
        numThree.text = RnumberThree.ToString();
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
        numTarg.text = targetNumber.ToString();*/

        // there's 6 permutations of 3 numbers
        int order = UnityEngine.Random.Range(0, 6);

        if (order == 0)
        {
            PlayerPrefs.SetInt("NumberOne", RnumberOne);
            PlayerPrefs.SetInt("NumberTwo", RnumberTwo);
            PlayerPrefs.SetInt("NumberThree", RnumberThree);
        }
        else if (order == 1)
        {
            PlayerPrefs.SetInt("NumberOne", RnumberOne);
            PlayerPrefs.SetInt("NumberTwo", RnumberThree);
            PlayerPrefs.SetInt("NumberThree", RnumberTwo);
        } else if (order == 2)
        {
            PlayerPrefs.SetInt("NumberOne", RnumberTwo);
            PlayerPrefs.SetInt("NumberTwo", RnumberOne);
            PlayerPrefs.SetInt("NumberThree", RnumberThree);
        }
        else if (order == 3)
        {
            PlayerPrefs.SetInt("NumberOne", RnumberTwo);
            PlayerPrefs.SetInt("NumberTwo", RnumberThree);
            PlayerPrefs.SetInt("NumberThree", RnumberOne);
        }
        else if (order == 4)
        {
            PlayerPrefs.SetInt("NumberOne", RnumberThree);
            PlayerPrefs.SetInt("NumberTwo", RnumberTwo);
            PlayerPrefs.SetInt("NumberThree", RnumberOne);
        }
        else 
        {
            PlayerPrefs.SetInt("NumberOne", RnumberThree);
            PlayerPrefs.SetInt("NumberTwo", RnumberOne);
            PlayerPrefs.SetInt("NumberThree", RnumberTwo);
        }
        if (PlayerPrefs.GetInt("Mode") == 3)
        {
            PlayerPrefs.SetInt("ExtraNum", UnityEngine.Random.Range(2, 10));
        }
   
        PlayerPrefs.SetInt("OperatorOne", operatorOne);
        PlayerPrefs.SetInt("OperatorTwo", operatorTwo);
        PlayerPrefs.SetInt("TargetNumber", targetNumber);
        turnsTillDivide = UnityEngine.Random.Range(2, 6);
        PlayerPrefs.SetInt("Divide", turnsTillDivide);
        yield return new WaitForSeconds(1f);
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
        if (!PlayerPrefs.HasKey("ExtraNum"))
        {
            PlayerPrefs.SetInt("ExtraNum", 0);
        }
        StartCoroutine(GenerateNum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
