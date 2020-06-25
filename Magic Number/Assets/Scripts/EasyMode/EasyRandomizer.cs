using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyRandomizer : MonoBehaviour
{
    public int targetNumber;
    public int numOne;
    public int numTwo;
    public int op;
    public int completed;
    public int failcount;

    public float targTest;
    public float testOne;
    public float testTwo;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("EasyTarget"))
        {
            PlayerPrefs.SetInt("EasyTarget", 0);
        }
        if (!PlayerPrefs.HasKey("EasyNumOne"))
        {
            PlayerPrefs.SetInt("EasyNumOne", 0);
        }
        if (!PlayerPrefs.HasKey("EasyNumTwo"))
        {
            PlayerPrefs.SetInt("EasyNumTwo", 0);
        }
        StartCoroutine(RandomizeNow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Genproblem()
    {
        StartCoroutine(RandomizeNow());
    }

    IEnumerator RandomizeNow()
    {
        targetNumber = UnityEngine.Random.Range(2, 82);
        numOne = UnityEngine.Random.Range(2, 10);
        op = UnityEngine.Random.Range(1, 13);
        completed = 0;
        failcount = 0;
        while (completed == 0)
        {
            if (failcount > 4)
            {
                targetNumber = UnityEngine.Random.Range(2, 82);
                numOne = UnityEngine.Random.Range(2, 10);
            }
            if (op == 1 || op ==  5 || op == 8)
            {
                numTwo = targetNumber - numOne;
                if (numTwo < 10 && numTwo > 1)
                {
                    completed = 1;
                }
                else
                {
                    numTwo = 10;
                    failcount++;
                }
            }
            else if (op == 2 || op == 6)
            {
                numTwo = targetNumber + numOne;
                if (numTwo < 10 && numTwo > 1)
                {
                    completed = 1;
                }
                else
                {
                    numTwo = 10;
                    failcount++;
                }
            }
            else if (op == 3 || op == 7 || op == 9 || op == 10 || op == 11 || op == 12)
            {
                targTest = targetNumber;
                testOne = numOne;
                numTwo = targetNumber / numOne;
                testTwo = targTest / testOne;
                if (numTwo == testTwo && numTwo < 10 && numTwo > 1)
                {
                    completed = 1;
                }
                else
                {
                    numTwo = 10;
                    failcount++;
                }
            }
            else
            {
                numTwo = targetNumber * numOne;
                if (numTwo < 10 && numTwo > 1)
                {
                    completed = 1;
                }
                else
                {
                    numTwo = 10;
                    failcount++;
                }
            }
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("EasyTarget", targetNumber);
        PlayerPrefs.SetInt("EasyNumOne", numOne);
        PlayerPrefs.SetInt("EasyNumTwo", numTwo);
    }
}
