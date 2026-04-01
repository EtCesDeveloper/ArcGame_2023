using System.Collections;
using UnityEngine;

public class Nube : MonoBehaviour
{

    [Range(0.5f, 1.5f)]
    public float velocidad;
    GameObject fondo;
    float limiteJuego, posicionInicialX;

    void Start()
    {

        fondo = GameObject.Find("Fondo");
        limiteJuego = fondo.GetComponent<SpriteRenderer>().bounds.extents.x;

        posicionInicialX = transform.position.x;

    }

    void Update()
    {
        //velocidad = 0.6f;
        Vector2 movimiento = new Vector2(Time.deltaTime * velocidad, 0);

        transform.Translate(movimiento);

        if (transform.position.x > limiteJuego * 1.25f)
        {
           // transform.localScale = new Vector3(Random.Range(0.2f, 0.4f), Random.Range(0.2f, 0.4f), transform.localScale.z);

            transform.position = new Vector2(posicionInicialX, Random.Range(0.5f, 1.5f));
        }

    }
}