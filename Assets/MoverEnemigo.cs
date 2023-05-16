using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    Transform jugador;
    UnityEngine.AI.NavMeshAgent pathfinder;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathfinder.SetDestination(jugador.position);
    }
}