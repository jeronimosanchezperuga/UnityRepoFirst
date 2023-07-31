using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitsAboveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] digitsAbove;
    [SerializeField] TextMeshProUGUI activeDigit;

    public void DeactivateAllDIgits()
    {
        foreach (TextMeshProUGUI d in digitsAbove)
        {
            d.gameObject.SetActive(false);
        }
    }

    public void ActivateDigitByIndex(int index)
    {
        activeDigit = digitsAbove[index];
        activeDigit.gameObject.SetActive(true);
    }
}
