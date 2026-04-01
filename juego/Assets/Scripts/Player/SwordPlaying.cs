using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPlaying : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpeD;

    [SerializeField] private Transform controladorGolpeI;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float dañoGolpe;

    [SerializeField] private float tiempoEAtaques;

    [SerializeField] private float tiempoPAtaque;

    private Animator animator;

    private GameObject esqueleto;

    private GameObject esqueleto1;

    private GameObject  seta;

    private GameObject seta1;

    private GameObject boss;


    private void Start()
    {
        animator = GetComponent<Animator>();
        esqueleto = GameObject.Find("Esqueleto");
        boss = GameObject.Find("Boss");
        esqueleto1 = GameObject.Find("Esqueleto1");
        seta = GameObject.Find("Seta");
        seta1 = GameObject.Find("Seta1");
    }

    private void Update()
    {
        if (tiempoPAtaque > 0)
        {
            tiempoPAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && tiempoPAtaque <= 0)
        {
            Golpe();
            tiempoPAtaque = tiempoEAtaques;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpeD.position, radioGolpe);
        Collider2D[] objetos1 = Physics2D.OverlapCircleAll(controladorGolpeI.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Esqueleto"))
            {
                
                    CustomEvent.Trigger(esqueleto, "Damage");

             }  else if (colisionador.CompareTag("Seta"))
            {
                CustomEvent.Trigger(seta, "Damage");
            }
            else if (colisionador.CompareTag("Seta1"))
            {
                CustomEvent.Trigger(seta1, "Damage");
            }
            else if (colisionador.CompareTag("Esqueleto1"))
            {
                CustomEvent.Trigger(esqueleto1, "Damage");
            }
            else if (colisionador.CompareTag("Boss"))
            {
                CustomEvent.Trigger(boss, "Damage");
            }

        }
        foreach (Collider2D colisionador in objetos1)
        {
            if (colisionador.CompareTag("Esqueleto"))
            {

                CustomEvent.Trigger(esqueleto, "Damage");

            }
            else if (colisionador.CompareTag("Seta"))
            {
                CustomEvent.Trigger(seta, "Damage");
            } else if (colisionador.CompareTag("Seta1"))
            {
                CustomEvent.Trigger(seta1, "Damage");
            }
            else if (colisionador.CompareTag("Esqueleto1"))
            {
                CustomEvent.Trigger(esqueleto1, "Damage");
            }
            else if (colisionador.CompareTag("Boss"))
            {
                CustomEvent.Trigger(boss, "Damage");
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpeD.position, radioGolpe);
        Gizmos.DrawWireSphere(controladorGolpeI.position, radioGolpe);
    }

}
