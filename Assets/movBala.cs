using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movBala : MonoBehaviour
{
    public float velocidad = 100.0f;
    public float valorHerida = 1.0f;
    private float timer = 5f;


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
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemigo"))
        {
            Debug.Log("He chocado con el enemigo");
            other.SendMessage("tocado", valorHerida, SendMessageOptions.DontRequireReceiver);
        }
    }
}
