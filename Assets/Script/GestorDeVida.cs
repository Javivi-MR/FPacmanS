using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GestorDeVida : MonoBehaviour
{
    public float Vida = 10.0f; //Vida del enemigo
    public float maxVida = 10.0f; //Vida maxima del enemigo
    public UnityEvent hesidoTocado; //Evento de que he sido tocado
    public UnityEvent estoyMuerto;  //Evento de que estoy muerto


    void tocado(float fuerza) //Funcion de que he sido tocado
    {
        Vida -= fuerza; //Resto la fuerza a la vida

        hesidoTocado.Invoke(); //Llamo al evento de que he sido tocado

        if(Vida <= 0) //Si la vida es menor o igual a 0
        {
            //Accion de que he muerto
            estoyMuerto.Invoke(); //Llamo al evento de que estoy muerto
        }
    }


}