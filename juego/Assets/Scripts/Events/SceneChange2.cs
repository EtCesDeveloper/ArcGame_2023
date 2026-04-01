using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange2 : MonoBehaviour
{

    [SerializeField] private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(col);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag( "Player"))
        {
            SceneManager.LoadScene("NivelBoss");
        }
    }

}
