using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathProblemGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt_operando1;
    [SerializeField] TextMeshProUGUI txt_operando2;
    [SerializeField] TextMeshProUGUI txt_operacion;
    [SerializeField] TMP_InputField input_respuesta;

    [SerializeField] int max1;
    [SerializeField] int max2;
    [SerializeField] int min;

    [SerializeField] int resultado;

    [SerializeField] GameObject panelAcertaste;
    [SerializeField] GameObject panelTeEquivocaste;
    [SerializeField] GameObject btn_Aceptar;
    GameObject panelResultado ;

    // Start is called before the first frame update
    void Start()
    {
        StartChallenge();
        input_respuesta.onValueChanged.AddListener(delegate
        {
            ValueChangeCheck();
        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && input_respuesta.text != string.Empty)
        {
            CheckResult();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void CheckResult()
    {
        panelResultado = panelTeEquivocaste;
        if (input_respuesta.text == resultado.ToString())
        {
            panelResultado = panelAcertaste;
        }
        panelResultado.SetActive(true);
    }

    public void NextChallenge()
    {
        panelResultado.SetActive(false);
        StartChallenge();
    }

    void GenerateOperation()
    {
        int op1 = Random.Range(min, max1 + 1);
        int op2 = Random.Range(min, max2 + 1);
        resultado = op1 + op2;

        txt_operando1.text = op1.ToString();
        txt_operando2.text = op2.ToString();
    }

    void StartChallenge()
    {
        input_respuesta.text = "";
        input_respuesta.Select();
        GenerateOperation();
        btn_Aceptar.SetActive(false);
    }

  

    public void RestartChallenge()
    {
        input_respuesta.text = "";
        input_respuesta.Select();
        btn_Aceptar.SetActive(false);
        panelResultado.SetActive(false);
    }

    void ValueChangeCheck()
    {
        btn_Aceptar.SetActive(true);
    }
}
