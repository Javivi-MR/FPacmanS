using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    private float  proximoDisparo = 0.0f; //Tiempo del proximo disparo
    private float tiempoDisparo = 0.3f; //Tiempo entre disparos

    public GameObject Bala; //Prefab de la bala

    private Transform salida; //Posicion de salida de la bala
 
    // Start is called before the first frame update
    void Start()
    {
        salida = GameObject.FindGameObjectWithTag("salida").transform; //Busco el objeto con el tag salida
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proximoDisparo && Input.GetMouseButtonDown(0)) //Si ha pasado el tiempo y se ha pulsado el boton izquierdo del raton
        {
            proximoDisparo = Time.time + tiempoDisparo; //Calculo el tiempo del proximo disparo
            GameObject nuevaBala = Instantiate(Bala, salida.position, salida.rotation); //Instancio la bala
        }
    }
}
