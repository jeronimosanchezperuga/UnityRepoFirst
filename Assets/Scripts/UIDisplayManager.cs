using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplayManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtNum1;
    [SerializeField] TextMeshProUGUI txtNum2;
   

    void Update()
    {
        
    }

    public void SetNum1(int num)
    {
        txtNum1.text = num.ToString();
    }

    public void SetNum2(int num)
    {
        txtNum2.text = num.ToString();
    }
}
