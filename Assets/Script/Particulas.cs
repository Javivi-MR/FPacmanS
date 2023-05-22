using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    public GameObject Particula; // Prefab de la particula a instanciar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z); // Posicion de la particula
        Instantiate(Particula,pos,Particula.transform.rotation); // Instancia la particula
    }
}
