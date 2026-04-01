using System.Collections;
using UnityEngine;

public class Estrella : MonoBehaviour
{

    [Range(5f, 15f)]
    public float velocidad;
    Material material;

    void Start()
    {

        material = GetComponent<SpriteRenderer>().material;

    }

    void Update()
    {

        StartCoroutine(Opacidad(1, 0.5f));

    }

    private IEnumerator Opacidad(float opacidadIn, float opacidadOut)
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b, opacidadIn); 
        while (material.color.a >= opacidadOut)
        {
            velocidad = 10.0f;

            material.color = new Color(material.color.r, material.color.g, material.color.b, material.color.a - velocidad * Time.deltaTime);
            yield return null;
        }


        material.color = new Color(material.color.r, material.color.g, material.color.b, opacidadOut); 
        while (material.color.a <= opacidadIn)
        {
            velocidad = 6.0f;
            material.color = new Color(material.color.r, material.color.g, material.color.b, material.color.a + velocidad * Time.deltaTime);
            yield return null;
        }


    }
}