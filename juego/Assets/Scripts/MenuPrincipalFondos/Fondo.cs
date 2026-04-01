
using UnityEngine;

public class Fondo : MonoBehaviour
{

    [Range(0.05f, 0.15f)]
    public float velocidad1, velocidad2, velocidad3;
    private GameObject fondo, colina11, colina12, colina21, colina22, colina31, colina32;
    private float anchoJuego;

    void Start()
    {

        fondo = GameObject.Find("Fondo");
        anchoJuego = fondo.GetComponent<SpriteRenderer>().bounds.extents.x * 2;

        colina11 = GameObject.Find("Colina11");
        colina12 = GameObject.Find("Colina12");
        colina21 = GameObject.Find("Colina21");
        colina22 = GameObject.Find("Colina22");
        colina31 = GameObject.Find("Colina31");
        colina32 = GameObject.Find("Colina32");

    }

    void Update()
    {

        velocidad1 = 0.06f;
        Vector2 movimiento1 = new Vector2(Time.deltaTime * velocidad1, 0);

        colina11.transform.Translate(movimiento1);
        colina12.transform.Translate(movimiento1);

        if (colina11.transform.position.x > anchoJuego)
        {
            colina11.transform.position = new Vector2(-anchoJuego + 0.01f, colina11.transform.position.y);
        }

        if (colina12.transform.position.x > anchoJuego)
        {
            colina12.transform.position = new Vector2(-anchoJuego + 0.01f, colina12.transform.position.y);
        }


        velocidad2 = 0.07f;
        Vector2 movimiento2 = new Vector2(-Time.deltaTime * velocidad2, 0);

        colina21.transform.Translate(movimiento2);
        colina22.transform.Translate(movimiento2);

        if (colina21.transform.position.x < -anchoJuego)
        {
            colina21.transform.position = new Vector2(anchoJuego - 0.01f, colina21.transform.position.y);
        }

        if (colina22.transform.position.x < -anchoJuego)
        {
            colina22.transform.position = new Vector2(anchoJuego - 0.01f, colina22.transform.position.y);
        }


        velocidad3 = 0.05f;
        Vector2 movimiento3 = new Vector2(Time.deltaTime * velocidad3, 0);

        colina31.transform.Translate(movimiento3);
        colina32.transform.Translate(movimiento3);

        if (colina31.transform.position.x > anchoJuego)
        {
            colina31.transform.position = new Vector2(-anchoJuego + 0.01f, colina31.transform.position.y);
        }

        if (colina32.transform.position.x > anchoJuego)
        {
            colina32.transform.position = new Vector2(-anchoJuego + 0.01f, colina32.transform.position.y);
        }

    }
}