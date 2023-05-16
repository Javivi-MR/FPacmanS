using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movBala : MonoBehaviour
{
    public float velocidad = 100.0f;
    public float valorHerida = 1.0f;
    private float timer = 5f;

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;

    int superPuntos_ = GestionPuntos.count;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad;
        transform.Translate(Vector3.up * movDistancia);

        timer -= Time.deltaTime;

        

        if (timer <= 0) // si el temporizador ha llegado a cero
        {
            Destroy(gameObject); // destruir el objeto
        }
        if(superPuntos_ == 1)
        {
            valorHerida = 2f;
        }
        if(superPuntos_ == 2)
        {
            valorHerida = 0.75f;
        }
        if(superPuntos_ == 3)
        {
            valorHerida = 0.75f;
        }
        if(superPuntos_ == 4)
        {
            valorHerida = 1.0f;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemigo"))
        {
            Debug.Log("He chocado con el enemigo");
            other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            if(!other.CompareTag("salida") && !other.CompareTag("Jugador"))
            Debug.Log("He chocado con " + other.tag);
            Destroy(gameObject);
        }
    }
}
