using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbersGenerator : MonoBehaviour
{
    public int GetRandomNumber(int lenght)
    {
        return UnityEngine.Random.Range(0,Convert.ToInt32(Mathf.Pow(10,lenght)));
    }
}
