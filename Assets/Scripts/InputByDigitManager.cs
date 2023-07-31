using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputByDigitManager : MonoBehaviour
{
    [SerializeField] TMP_InputField[] inputs;
    [SerializeField] TMP_InputField activeInput;
    [SerializeField] int currentIndex = 0;
    [SerializeField] bool isLastDigit;
    DigitsAboveManager digitsAboveManager;

    private void Awake()
    {
        digitsAboveManager = FindObjectOfType<DigitsAboveManager>();
        digitsAboveManager.DeactivateAllDIgits();
    }

    public TMP_InputField SetActiveInput(int index, bool isLast)
    {
        isLastDigit = isLast;
        currentIndex = index;
        activeInput = inputs[index];
        activeInput.gameObject.SetActive(true);
        activeInput.onValueChanged.AddListener(delegate
        {
            if (activeInput.text !="")
            {
                ValueChangeCheck(Convert.ToInt32(activeInput.text), isLast);
            }
        }
        );
        return activeInput;
    }

    private void ValueChangeCheck(int n, bool isLast)
    {
        if (n > 18 || n<0)
        {
            ClearFieldOnInvalidValue();
        } else if (n > 9)
        {
            //solo si no es el último dígito
            if (!isLast)
            {
                activeInput.text = (n - 10).ToString();
                digitsAboveManager.ActivateDigitByIndex(currentIndex);
            }
            else
            {
                Debug.Log(activeInput.GetComponentInChildren<RectTransform>().gameObject.name);
                RectTransformExtensions.SetLeft(activeInput.GetComponentInChildren<RectTransform>(),10);
            }
        }
    }

    private void ClearFieldOnInvalidValue()
    {
        Debug.Log("Valor no válido. No puede ser mayor que 18");
        activeInput.text = String.Empty;
    }

    public void SetInitalInputSetup()
    {
        ClearAllInputs();
        HideAllInputs();
        SetActiveInput(0, false);
        digitsAboveManager.DeactivateAllDIgits();
    }

    private void ClearAllInputs()
    {
        foreach (TMP_InputField i in inputs)
        {
            i.text = String.Empty;
        }
    }

    void HideAllInputs()
    {
        foreach (TMP_InputField i in inputs)
        {
            i.gameObject.SetActive(false);
        }
    }

    public int GetEnteredNumber(int lastIndex)
    {
        string number = "";
        for (int i = lastIndex; i>=0;i--)
        {
            number += inputs[i].text;
        }
        Debug.Log("Entered number: " + number);
        return int.Parse(number);
    }
}
