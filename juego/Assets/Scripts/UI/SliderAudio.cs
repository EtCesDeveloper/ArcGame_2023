using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudio : MonoBehaviour
{
    [SerializeField] Slider volumenSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volumenMusica"))
        {
            PlayerPrefs.SetFloat("volumenMusica", 0.5f);
            Cargar();
        } else
        {
            Cargar();
        }

    }

    // Update is called once per frame
    public void cambiarVolumen()
    {
        AudioListener.volume = volumenSlider.value;
        Guardar();
    }

    private void Cargar()
    {
        volumenSlider.value = PlayerPrefs.GetFloat("volumenMusica");
        AudioListener.volume = volumenSlider.value;
    }

    private void Guardar()
    {
        PlayerPrefs.SetFloat("volumenMusica", volumenSlider.value);
    }
}
