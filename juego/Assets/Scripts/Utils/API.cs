using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using System;
using Ludiq;
using UnityEngine.SceneManagement;

public class Character
{
    public String name;
    public String description;
}

public class API : MonoBehaviour
{

    public Text texto;
    private string frase = "";
    public static API instancia;

    private void Awake()
    {
        if (API.instancia == null)
        {
            instancia = this;
        } else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!MenuPausa.juegoCerrado)
        {
            StartCoroutine(GetName("arc"));
        } else
        {
            print("Personaje detectado");
            StartCoroutine(Reloj());
        }
        
    }

    public IEnumerator GetName(string name)
    {
        UnityWebRequest wwwG = UnityWebRequest.Get("https://www.moogleapi.com/api/v1/characters/search?name=" + name);
        yield return wwwG.SendWebRequest();//Ejecuta la query

        if (!(wwwG.result == UnityWebRequest.Result.ProtocolError && wwwG.result == UnityWebRequest.Result.ConnectionError))
        {
            JSONNode datos = JSON.Parse(wwwG.downloadHandler.text);
            JSONNode nombreJug = datos[0];
            String descripcion = "el personaje es un joven aprendiz de magia en busca de su poder mágico para completar su formación. Con un fuerte deseo de aprender y una pasión por la magia, está decidido a superar cualquier obstáculo que se le presente en su camino para alcanzar su destino y convertirse en un mago poderoso.";

            Character arc = new Character();
            arc.name = nombreJug["name"];
            arc.description = descripcion;

            String jsonData = JsonUtility.ToJson(arc);

            UnityWebRequest wwwP = UnityWebRequest.Put("http://localhost:8080/api/characters/create", jsonData);
            wwwP.method = UnityWebRequest.kHttpVerbPOST;

            wwwP.SetRequestHeader("Content-Type", "application/json");
            wwwP.SetRequestHeader("Accept", "application/json");

            yield return wwwP.SendWebRequest();

            if (wwwG.result == UnityWebRequest.Result.ProtocolError || wwwG.result == UnityWebRequest.Result.ConnectionError)
            {
                print(wwwP.error);
            }
            else
            {
                print("Personaje creado");
            }

            UnityWebRequest wwwGDB = UnityWebRequest.Get("http://localhost:8080/api/characters/1");
            yield return wwwGDB.SendWebRequest();
            
            if (!(wwwGDB.result == UnityWebRequest.Result.ProtocolError && wwwGDB.result == UnityWebRequest.Result.ConnectionError))
            {
                JSONNode datosDB = JSON.Parse(wwwGDB.downloadHandler.text);
                //print(datosDB["name"] + ", " + datosDB["description"]);
                frase = datosDB["name"] + ", " + datosDB["description"];
                GameManager.instance.frase = frase;
                StartCoroutine(Reloj());

            }
        }
    }

    public IEnumerator Reloj()
    {
        foreach (char character in GameManager.instance.frase)
        {
            texto.text += character;
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

}
