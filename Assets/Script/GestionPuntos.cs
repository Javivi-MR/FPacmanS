using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GestionPuntos : MonoBehaviour
{
    private int puntos = 0; // Puntos obtenidos
    private int superPuntos = 0; // SuperPuntos obtenidos
    public static int count = 0; // Contador de superPuntos obtenidos

    public GameObject Particula; // Prefab de la partícula
    private GameObject nuevaParticula; // Instancia de la partícula
    public GameObject ParticulaSuperDot; // Prefab de la partícula
    private GameObject nuevaParticulaSuperDot; // Instancia de la partícula

    public Text textoPuntos; // Texto para mostrar los puntos obtenidos

    public GameObject gun1; // Prefab de la gun1
    public GameObject gun2; // Prefab de la gun2
    public GameObject gun3; // Prefab de la gun3
    public GameObject gun4; // Prefab de la gun4

    public GameObject guncamera; // Prefab de la guncamera

    public AudioClip audioGun1; // Sonido de la gun1
    private AudioSource audioSGun1; // Instancia del sonido de la gun1
    public AudioClip audioGun2; // Sonido de la gun2
    private AudioSource audioSGun2; // Instancia del sonido de la gun2
    public AudioClip audioGun3; // Sonido de la gun3
    private AudioSource audioSGun3; // Instancia del sonido de la gun3
    public AudioClip audioGun4; // Sonido de la gun4
    private AudioSource audioSGun4; // Instancia del sonido de la gun4
    public AudioClip comePuntos; // Sonido de cuando se come un punto
    private AudioSource audioSComePuntos; // Instancia del sonido de cuando se come un punto


    private float  proximoDisparo = 1f; // Tiempo para el próximo disparo
    private float tiempoDisparo = 1f; // Tiempo entre disparos

    public GameObject Bala; // Prefab de la bala

    private Transform salida; // Transform de la salida de la bala

    

    // Start is called before the first frame update
    void Start()
    {
        salida = GameObject.FindGameObjectWithTag("salida").transform; // Obtener el Transform de la salida de la bala
        audioSGun1 = gameObject.AddComponent<AudioSource>(); // Añadir un componente de audio a la instancia
        audioSGun1.clip = audioGun1; // Asignar el audio a la instancia
        audioSGun2 = gameObject.AddComponent<AudioSource>(); // Añadir un componente de audio a la instancia
        audioSGun2.clip = audioGun2; // Asignar el audio a la instancia
        audioSGun3 = gameObject.AddComponent<AudioSource>(); // Añadir un componente de audio a la instancia
        audioSGun3.clip = audioGun3; // Asignar el audio a la instancia
        audioSGun4 = gameObject.AddComponent<AudioSource>(); // Añadir un componente de audio a la instancia
        audioSGun4.clip = audioGun4; // Asignar el audio a la instancia
        audioSComePuntos = gameObject.AddComponent<AudioSource>(); // Añadir un componente de audio a la instancia
        audioSComePuntos.clip = comePuntos; // Asignar el audio a la instancia

        guncamera.SetActive(false); // Desactivar la guncamera
    }

    // Update is called once per frame
    void Update()
    {
        if(puntos == 150) // Si se han obtenido todos los puntos
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

        if(Time.time >= proximoDisparo && superPuntos > 0) // Si se puede disparar
        {
            if(Input.GetMouseButtonDown(0) || (Gamepad.current != null && Gamepad.current.rightTrigger.wasPressedThisFrame)) // Si se pulsa el botón izquierdo del ratón o el gatillo derecho del mando
            {
                proximoDisparo = Time.time + tiempoDisparo; // Actualizar el tiempo para el próximo disparo

                Debug.Log("tiempo actual: " + Time.time); 
                Debug.Log("tiempo proximo disparo: " + proximoDisparo);

                GameObject nuevaBala = Instantiate(Bala, salida.position, salida.rotation); // Instanciar una bala
                switch(superPuntos) 
                {
                case 1:
                    audioSGun1.Play(); // Reproducir el sonido de la gun1
                    break;
                case 2:
                    audioSGun2.Play(); // Reproducir el sonido de la gun2
                    break;
                case 3:
                    audioSGun3.Play(); // Reproducir el sonido de la gun3
                    break;
                case 4:
                    audioSGun4.Play(); // Reproducir el sonido de la gun4
                    break;
                }
            }
        }
        count = superPuntos; // Actualizar el contador de superPuntos
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dot") // Si el objeto tiene el tag Dot
        {
            puntos++; // Aumentar los puntos
            Debug.Log("Puntos: " + puntos);
            other.enabled = false; // Desactivar el Collider antes de destruir el objeto
            //take the position of the dot and instantiate the particle system in that position
            Vector3 position = other.transform.position;
            nuevaParticula = Instantiate(Particula, position, Particula.transform.rotation);
            //get that new Particle System and destroy it after 2 seconds
            Destroy(nuevaParticula.gameObject, 2f);  
            Destroy(other.gameObject); // Destruir el objeto
            audioSComePuntos.Play(); // Reproducir el sonido de cuando se come un punto
            textoPuntos.text = "Puntos obtenidos: " + puntos + "/150"; // Actualizar el texto de los puntos obtenidos
        }
        if(other.gameObject.tag == "SuperDot") // Si el objeto tiene el tag SuperDot
        {
            superPuntos++; // Aumentar los superPuntos
            Debug.Log("SuperPuntos: " + superPuntos); 
            other.enabled = false; // Desactivar el Collider antes de destruir el objeto
            //take the position of the dot and instantiate the particle system in that position
            Vector3 position = other.transform.position; 
            nuevaParticulaSuperDot = Instantiate(ParticulaSuperDot, position, ParticulaSuperDot.transform.rotation);
            //get that new Particle System and destroy it after 2 seconds
            Destroy(nuevaParticulaSuperDot.gameObject, 2f);
            Destroy(other.gameObject);
            switch (superPuntos)
            {
                case 1:
                    guncamera.SetActive(true); // Activar la guncamera
                    gun1.SetActive(true); // Activar la gun1
                    proximoDisparo = 1f; // Actualizar el tiempo para el próximo disparo
                    tiempoDisparo = 1f; // Actualizar el tiempo entre disparos
                    break;
                case 2: 
                    gun1.SetActive(false); // Desactivar la gun1
                    gun2.SetActive(true);  // Activar la gun2
                    proximoDisparo = 1.5f; // Actualizar el tiempo para el próximo disparo
                    tiempoDisparo = 1f; // Actualizar el tiempo entre disparos
                    break;
                case 3:
                    gun2.SetActive(false); // Desactivar la gun2
                    gun3.SetActive(true); // Activar la gun3
                    proximoDisparo = 0.4f;  // Actualizar el tiempo para el próximo disparo
                    tiempoDisparo = 0.4f;   // Actualizar el tiempo entre disparos
                    break;
                case 4:
                    gun3.SetActive(false); // Desactivar la gun3
                    gun4.SetActive(true); // Activar la gun4
                    proximoDisparo = 0.6f; // Actualizar el tiempo para el próximo disparo
                    tiempoDisparo = 0.4f; // Actualizar el tiempo entre disparos
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
        if(other.gameObject.tag == "Enemigo") // Si el objeto tiene el tag Enemigo
        {
            SceneManager.LoadScene("Game Over",LoadSceneMode.Single); // Cargar la escena Game Over
        }
    }
}
