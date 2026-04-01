using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañado : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void RecibeDaño(float daño)
    {
        animator.SetTrigger("Hit");
        vida -= daño;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {

        animator.SetTrigger("Death");
        animator.enabled = false;
        //animator.SetTrigger("Dead");
       // animator.SetBool("Muerto",true);

    }

    void Update()
    {
        
    }
}
