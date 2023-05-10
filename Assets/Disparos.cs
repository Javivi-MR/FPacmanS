using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    private float  proximoDisparo = 0.0f;
    private float tiempoDisparo = 0.3f;

    public GameObject Bala;

    private Transform salida;

    // Start is called before the first frame update
    void Start()
    {
        //salida = gameObject.transform.GetChild(0).transform;
        salida = GameObject.FindGameObjectWithTag("salida").transform;


    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= proximoDisparo && Input.GetMouseButtonDown(0))
        {
            proximoDisparo = Time.time + tiempoDisparo;
            GameObject nuevaBala = Instantiate(Bala, salida.position, salida.rotation);
        }

        


    }
}
