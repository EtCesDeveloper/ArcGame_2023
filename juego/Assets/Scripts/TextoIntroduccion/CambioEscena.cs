using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    public float tiempoInicio;
    public float tiempoFinal;

    void Update()
    {
        tiempoInicio += Time.deltaTime;
        if (tiempoInicio >= tiempoFinal)
        {
            SceneManager.LoadScene("Introduction");
        }
    }
}
