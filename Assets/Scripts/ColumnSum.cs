using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSum : MonoBehaviour
{
    [SerializeField] int num1;
    [SerializeField] int num2;
    [SerializeField] int min;
    [SerializeField] int lenght;
    [SerializeField] int activeDigitIndex = 0;
    [SerializeField] int sumResult;
    [SerializeField] int smallerLastIndex;
    [SerializeField] int greaterLastIndex;
    UIDisplayManager uiMngr;
    NumberFrameManager frameManager;
    InputByDigitManager inputsManager;

    void Awake()
    {
        uiMngr = FindObjectOfType<UIDisplayManager>();
        frameManager = FindObjectOfType<NumberFrameManager>();
        inputsManager = FindObjectOfType<InputByDigitManager>();
    }

    void Start()
    {
        GenerateNewOperation();
    }

    private int SumDigitsByIndex(int num1, int num2, int activeDigitIndex)
    {
        int result = -1;
        result = GetDigitByIndex(num1, activeDigitIndex) + GetDigitByIndex(num2, activeDigitIndex);
        return result;
    }
    
    private int GetDigitByIndex(int num, int index)
    {
        int digit = 0;
        string numString = num.ToString();
        int lastCharIndex = numString.Length - 1;
        if (index <= lastCharIndex)
        {
            digit = int.Parse(numString[lastCharIndex - index].ToString());
        }
        return digit;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (activeDigitIndex < greaterLastIndex)
            {
            PerformOperation();
            AdvanceToDigit(1);

            }
            else
            {
                Debug.Log("No hay más dígitos");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && activeDigitIndex>0)
        {
            AdvanceToDigit(-1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateNewOperation();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckResult();
        }
    }

    void AdvanceToDigit(int step)
    {
        activeDigitIndex+=step;
        ActivateDigit();
    }

    void ActivateDigit()
    {
        frameManager.ActivateFrameByIndex(activeDigitIndex);
        inputsManager.SetActiveInput(activeDigitIndex, activeDigitIndex >= smallerLastIndex).Select();
    }

    void GenerateNewOperation()
    {
        activeDigitIndex = 0;
        GenerateNumbers();
        CalculateLastIndexes();
        inputsManager.SetInitalInputSetup();
        ActivateDigit();
        UpdateUI();
    }

    private void CalculateLastIndexes()
    {
        int num1Lenght = num1.ToString().Length;
        int num2Lenght = num2.ToString().Length;
        
        if (num1>num2)
        {
            smallerLastIndex = num2Lenght - 1;
            greaterLastIndex = num1Lenght - 1;
        }
        else
        {
            smallerLastIndex = num1Lenght - 1;
            greaterLastIndex = num2Lenght - 1;
        }
    }

    void GenerateNumbers()
    {
        num1 = UnityEngine.Random.Range(min, Convert.ToInt32(Mathf.Pow(10, lenght)));
        num2 = UnityEngine.Random.Range(min, Convert.ToInt32(Mathf.Pow(10, lenght)));
    }

    public void PerformOperation()
    {
        sumResult = SumDigitsByIndex(num1, num2, activeDigitIndex);
    }

    void UpdateUI()
    {
        uiMngr.SetNum1(num1);
        uiMngr.SetNum2(num2);
    }

    public void CheckResult()
    {
        //obtener el nro ingresado formado por todos los inputs
        if (inputsManager.GetEnteredNumber(greaterLastIndex) == num1+num2 )
        {
            Debug.Log("Correcto");
        }
        else
        {
            Debug.Log("Incorrecto");
        }
    }
}