using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GestionPuntos : MonoBehaviour
{
    private int puntos = 0;
    private int superPuntos = 0;
    public static int count = 0;

    public Text textoPuntos;

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    public GameObject gun4;

    public GameObject guncamera;

    public AudioClip audioGun1;
    public Animation animationgun1;
    private AudioSource audioSGun1;
    public AudioClip audioGun2;
    public Animation animationgun2;
    private AudioSource audioSGun2;
    public AudioClip audioGun3;
    public Animation animationgun3;
    private AudioSource audioSGun3;
    public AudioClip audioGun4;
    public Animation animationgun4;
    private AudioSource audioSGun4;
    public AudioClip comePuntos;
    private AudioSource audioSComePuntos;


    private float  proximoDisparo = 0.2f;
    private float tiempoDisparo = 0.3f;

    public GameObject Bala;

    private Transform salida;

    

    // Start is called before the first frame update
    void Start()
    {
        salida = GameObject.FindGameObjectWithTag("salida").transform;
        audioSGun1 = gameObject.AddComponent<AudioSource>();
        audioSGun1.clip = audioGun1;
        audioSGun2 = gameObject.AddComponent<AudioSource>();
        audioSGun2.clip = audioGun2;
        audioSGun3 = gameObject.AddComponent<AudioSource>();
        audioSGun3.clip = audioGun3;
        audioSGun4 = gameObject.AddComponent<AudioSource>();
        audioSGun4.clip = audioGun4;
        audioSComePuntos = gameObject.AddComponent<AudioSource>();
        audioSComePuntos.clip = comePuntos;

        guncamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(puntos == 150)
        {
            //if the actual scene is Nivel 1 then load Nivel 2
            if(SceneManager.GetActiveScene().name == "Nivel 1")
            {
                SceneManager.LoadScene("Nivel 2",LoadSceneMode.Single);
            }
            //if the actual scene is Nivel 2 then load Nivel 3
            if(SceneManager.GetActiveScene().name == "Nivel 2")
            {
                SceneManager.LoadScene("Nivel 3",LoadSceneMode.Single);
            }
            //if the actual scene is Nivel 3 then load Nivel 4
            if(SceneManager.GetActiveScene().name == "Nivel 3")
            {
                SceneManager.LoadScene("You Win",LoadSceneMode.Single);
            }
        }

        if(Time.time >= proximoDisparo && Input.GetMouseButtonDown(0) && superPuntos > 0)
        {
            proximoDisparo = Time.time + tiempoDisparo;

            GameObject nuevaBala = Instantiate(Bala, salida.position, salida.rotation);
            switch(superPuntos)
            {
            case 1:
                audioSGun1.Play();
                animationgun1.wrapMode = WrapMode.Once;
                animationgun1.Play();
                break;
            case 2:
                audioSGun2.Play();
                animationgun2.wrapMode = WrapMode.Once;
                animationgun2.Play();
                break;
            case 3:
                audioSGun3.Play();
                animationgun3.wrapMode = WrapMode.Once;
                animationgun3.Play();
                break;
            case 4:
                audioSGun4.Play();
                animationgun4.wrapMode = WrapMode.Once;
                animationgun4.Play();
                break;
            }
        }
        count = superPuntos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dot")
        {
            puntos++;
            Debug.Log("Puntos: " + puntos);
            other.enabled = false; // Desactivar el Collider antes de destruir el objeto
            Destroy(other.gameObject);
            audioSComePuntos.Play();
            textoPuntos.text = "Puntos obtenidos: " + puntos + "/150";
        }
        if(other.gameObject.tag == "SuperDot")
        {
            superPuntos++;
            Debug.Log("SuperPuntos: " + superPuntos);
            other.enabled = false; // Desactivar el Collider antes de destruir el objeto
            Destroy(other.gameObject);
            switch (superPuntos)
            {
                case 1:
                    guncamera.SetActive(true);
                    gun1.SetActive(true);
                    proximoDisparo = 0.2f;
                    tiempoDisparo = 0.2f;
                    break;
                case 2:
                    gun1.SetActive(false);
                    gun2.SetActive(true);
                    proximoDisparo = 11.2f;
                    tiempoDisparo = 0.2f;
                    break;
                case 3:
                    gun2.SetActive(false);
                    gun3.SetActive(true);
                    proximoDisparo = 0.2f;
                    tiempoDisparo = 0.2f;
                    break;
                case 4:
                    gun3.SetActive(false);
                    gun4.SetActive(true);
                    proximoDisparo = 0.6f;
                    tiempoDisparo = 0.2f;
                    break;
            }
        }
        if(other.gameObject.tag == "PortalDerecho")
        {
            //teleport the player to the left portal x = his actual postion - 20 , y = his actual position, z = his actual position
            // Obtén la posición actual del jugador
            Vector3 playerPosition = transform.position;
            
            // Calcula la nueva posición, restando 20 a la x actual
            float newX = playerPosition.x - 62; 
            float newY = playerPosition.y; 
            float newZ = playerPosition.z;
            Vector3 newPosition = new Vector3(newX, newY, newZ);
            
            // Teletransporta el jugador a la nueva posición
            transform.position = newPosition; 
        }
        if(other.gameObject.tag == "PortalIzquierdo")
        {
                        //teleport the player to the left portal x = his actual postion - 20 , y = his actual position, z = his actual position
            // Obtén la posición actual del jugador
            Vector3 playerPosition = transform.position;
            
            // Calcula la nueva posición, restando 20 a la x actual
            float newX = playerPosition.x + 62; 
            float newY = playerPosition.y; 
            float newZ = playerPosition.z;
            Vector3 newPosition = new Vector3(newX, newY, newZ);
            
            // Teletransporta el jugador a la nueva posición
            transform.position = newPosition; 
        }
        if(other.gameObject.tag == "Enemigo")
        {
            SceneManager.LoadScene("Game Over",LoadSceneMode.Single);
        }
    }
}
