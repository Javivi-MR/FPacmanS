using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionPuntos : MonoBehaviour
{
    private int puntos = 0;

    public Text textoPuntos;

    public GameObject gun1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dot")
        {
            puntos++;
            Debug.Log("Puntos: " + puntos);
            Destroy(other.gameObject);
            textoPuntos.text = "Puntos obtenidos: " + puntos;
        }
    }
}
