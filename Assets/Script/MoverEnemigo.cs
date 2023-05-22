using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    Transform jugador; // Posicion del jugador
    UnityEngine.AI.NavMeshAgent pathfinder; // Componente de navegacion

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform; // Busca el objeto con el tag Jugador
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>(); // Obtiene el componente de navegacion
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(jugador.position); // Establece la posicion del jugador como destino
    }
}