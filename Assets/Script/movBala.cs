using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movBala : MonoBehaviour
{
    public float velocidad = 100.0f; // velocidad de la bala
    public float valorHerida = 1.0f; // valor de la herida
    private float timer = 5f; // tiempo de vida de la bala

    int superPuntos_ = GestionPuntos.count; // variable para saber el valor de los puntos


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movDistancia = Time.deltaTime * velocidad; // distancia de movimiento
        transform.Translate(Vector3.up * movDistancia); // movimiento de la bala

        timer -= Time.deltaTime; // decrementar el temporizador

        

        if (timer <= 0) // si el temporizador ha llegado a cero
        {
            Destroy(gameObject); // destruir el objeto 
        }
        if(superPuntos_ == 1)
        {
            valorHerida = 0.5f; // valor de la herida equivalente a la arma 1
        }
        if(superPuntos_ == 2)
        {
            valorHerida = 1f; // valor de la herida equivalente a la arma 2
        }
        if(superPuntos_ == 3)
        {
            valorHerida = 1.5f; // valor de la herida equivalente a la arma 3
        }
        if(superPuntos_ == 4)
        {
            valorHerida = 2f; // valor de la herida equivalente a la arma 4
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemigo")) // si el objeto colisiona con el enemigo
        {
            Debug.Log("He chocado con el enemigo"); // mensaje de comprobacion
            other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver); // envio del mensaje de herida
        }
    }
}
