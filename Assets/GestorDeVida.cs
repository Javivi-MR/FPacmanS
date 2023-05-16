using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GestorDeVida : MonoBehaviour
{
    public float Vida = 10.0f;
    public float maxVida = 10.0f;
    public UnityEvent hesidoTocado;
    public UnityEvent estoyMuerto;


    void tocado(float fuerza)
    {
        Vida -= fuerza;

        hesidoTocado.Invoke();

        if(Vida <= 0)
        {
            //Accion de que he muerto
            estoyMuerto.Invoke();
        }
    }


}