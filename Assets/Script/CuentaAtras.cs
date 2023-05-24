using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuentaAtras : MonoBehaviour
{
    public Button btn; //Boton para empezar

    public Text[] numeros; //Array de numeros

    private int mostrar; //Numero a mostrar

    private bool contar; //Contar

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(Pulsado); //Añado el evento al boton
        contar = false; //Inicializo contar
        mostrar = 3; //Inicializo mostrar
    }
    
    // Update is called once per frame
    private void Update() {
        if(Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame) //Si se pulsa el boton start del mando
        {
            Pulsado(); //Llamo a la funcion pulsado
        }
    }

    private void FixedUpdate() { 
        if(contar) // Si contar es true
        {
            switch (mostrar)
            {
                case 0:
                    //start NextScene 
                    SceneManager.LoadScene("Nivel 1",LoadSceneMode.Single); //Cargo la escena
                    break;
                case 1:
                    numeros[0].gameObject.SetActive(true); //Activo el primer numero
                    numeros[1].gameObject.SetActive(false); //Desactivo el segundo numero
                    break;
                case 2:
                    numeros[1].gameObject.SetActive(true); //Activo el segundo numero
                    numeros[2].gameObject.SetActive(false); //Desactivo el tercer numero
                    break;
                case 3:
                    numeros[2].gameObject.SetActive(true); //Activo el tercer numero
                    break;
            }
            StartCoroutine(Esperar()); //Espero un segundo
            contar = false; //Desactivo contar
            mostrar--; //Decremento mostrar
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1); //Espero un segundo
        contar = true; //Activo contar
    }

    void Pulsado()
    {
        numeros[2].gameObject.SetActive(true); //Activo el tercer numero
        contar = true; //Activo contar
    }
}
