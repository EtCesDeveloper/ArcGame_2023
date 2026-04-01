using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject menuManual;
    private bool juegoPausado = false;
    public static bool juegoCerrado;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            } else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;//Congela la pantalla
        button.SetActive(false);
        menuPausa.SetActive(true);
        menuOpciones.SetActive(false);
        menuManual.SetActive(false);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;//Descongela la pantalla
        button.SetActive(true);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        menuManual.SetActive(false);
    }

    public void Opciones()
    {
        Time.timeScale = 0f;
        button.SetActive(false);
        menuPausa.SetActive(false);
        menuManual.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void AtrasOpciones()
    {
        Time.timeScale = 0f;
        button.SetActive(false);
        menuOpciones.SetActive(false);
        menuManual.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Manual()
    {
        Time.timeScale = 0f;
        button.SetActive(false);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        menuManual.SetActive(true);
    }

    public void AtrasManual()
    {
        Time.timeScale = 0f;
        button.SetActive(false);
        menuManual.SetActive(false);
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void Cerrar()
    {
        Time.timeScale = 1f;
        juegoCerrado = true;
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
