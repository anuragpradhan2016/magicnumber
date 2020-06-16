using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomProblem : MonoBehaviour
{
    public static string randomProblem = "";
    // For operators, 0 => +, 1 => -, 2 => *, 3 => /

    public static IEnumerator generateProblem(int lowerBound, int higherBound, bool forceDivision)

     {
        int divisionOperators = -1; // which operators should be division: -1 => none, 0,1 => 1st operator is division, 2,3 => 2nd operator is division, 4 => both operators are division

        if (forceDivision)
        {
            divisionOperators = UnityEngine.Random.Range(0, 5);
        }

        int firstNumber = UnityEngine.Random.Range(lowerBound, higherBound);
        int targetNumber = firstNumber;

        int firstOperator =  divisionOperators == 0 || divisionOperators == 1 || divisionOperators == 4 ? 3 : UnityEngine.Random.Range(0, 3);
        int secondNumber = UnityEngine.Random.Range(lowerBound, higherBound);

        if (firstOperator == 0)
        {
            targetNumber += secondNumber;
        } else if (firstOperator == 1)
        {

            // if the first number is 2 and the first operator is -, then just retart (TODO)
            if (firstNumber == 2)
            {
                RandomProblem.generateProblem(lowerBound, higherBound, forceDivision);
            }
            // just easier and cleaner to stick to positive numbers (prime, division, etc)
            while (targetNumber - secondNumber <= 0)
            {
                secondNumber = UnityEngine.Random.Range(lowerBound, higherBound);
                yield return null;
            }

            targetNumber -= secondNumber;
        } else if (firstOperator == 2)
        {
            targetNumber *= secondNumber;
        } else
        {
            // if prime, we can only select 1 or targetNumber as the second number
            if (RandomProblem.isPrime(targetNumber))
            {
                secondNumber = UnityEngine.Random.Range(0, 2) == 0 ? 1 : targetNumber;
                targetNumber /= secondNumber;
            }
            else
            {
                int count = 0;

                // after 100 iterations, we will non randomly find a factor of targetNumber
                while (targetNumber % secondNumber != 0 && count < 100)
                {
                    secondNumber = UnityEngine.Random.Range(lowerBound, higherBound);
                    count++;
                    yield return null;
                }

                if (count < 100)
                {
                    targetNumber /= secondNumber;
                }
                else
                {
                    // go down from higherBound, it will find 1 (which divides all numbers)
                    secondNumber = higherBound;
                    while (targetNumber % secondNumber != 0)
                    {
                        secondNumber--;
                        yield return null;
                    }

                    targetNumber /= secondNumber;
                }
            }
        }


        int secondOperator = divisionOperators == 2 || divisionOperators == 3 || divisionOperators == 4 ? 3 : UnityEngine.Random.Range(0, 3);
        int thirdNumber = UnityEngine.Random.Range(lowerBound, higherBound);

        if (secondOperator == 0)
        {
            targetNumber += thirdNumber;
        }
        else if (secondOperator == 1)
        {
            // if the target number is 2 and the second operator is -, then just retart (TODO)
            if (targetNumber == 2)
            {
                RandomProblem.generateProblem(lowerBound, higherBound, forceDivision);
            }

            while (targetNumber - thirdNumber <= 0)
            {
                thirdNumber = UnityEngine.Random.Range(lowerBound, higherBound);
                yield return null;
            }

            targetNumber -= thirdNumber;
        }
        else if (secondOperator == 2)
        {
            targetNumber *= thirdNumber;
        }
        else
        {
            // if prime, we can only select 1 or targetNumber as the second number
            if (RandomProblem.isPrime(targetNumber))
            {
                thirdNumber = UnityEngine.Random.Range(0, 2) == 0 ? 1 : targetNumber;
                targetNumber /= thirdNumber;
            }
            else
            {
                int count = 0;

                // after 100 iterations, we will non randomly find a factor of targetNumber
                while (targetNumber % thirdNumber != 0 && count < 100)
                {
                    thirdNumber = UnityEngine.Random.Range(lowerBound, higherBound);
                    count++;
                    yield return null;
                }

                if (count < 100)
                {
                    targetNumber /= thirdNumber;
                }
                else
                {
                    // go down from higherBound, it will find 1 (which divides all numbers)
                    thirdNumber = higherBound;
                    while (targetNumber % thirdNumber != 0)
                    {
                        thirdNumber--;
                        yield return null;
                    }

                    targetNumber /= thirdNumber;
                }
            }
        }


        UnityEngine.Debug.Log("Answer: " + targetNumber + "," + firstNumber + "," + secondNumber + "," + thirdNumber + " Operators: " + firstOperator + "," + secondOperator);
        RandomProblem.randomProblem =  "" + targetNumber + "," + firstNumber + "," + secondNumber + "," + thirdNumber;
    }

    private static bool isPrime(int x)
    {
        int a = 0;
        for (int i = 1; i <= x; i++)
        {
            if (x % i == 0)
            {
                a++;
            }
        }

        return a == 2;
    }
}
