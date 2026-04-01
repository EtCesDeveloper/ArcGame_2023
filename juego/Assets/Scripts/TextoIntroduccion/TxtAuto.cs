using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TxtAuto : MonoBehaviour
{
    public string frase = "";
    public Text texto;

    

    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        
        foreach (char character in frase)
        {
            texto.text += character;
            yield return new WaitForSeconds(0.08f);
        }
    }
}
