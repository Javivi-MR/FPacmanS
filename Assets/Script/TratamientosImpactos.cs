using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TratamientosImpactos : MonoBehaviour
{
    float vidarestante; //Vida restante del enemigo
    public GameObject enemyPrefab; //Prefab del enemigo

    public delegate void OnDeath(); //Creo el evento
    public static event OnDeath OnDeathEnemigo; // Indico que función se va encargar de ello

    public void hesidoTocadoINSIDE()
    {
        Debug.Log("Enemigo- Me han tocado");
        vidarestante = GetComponent<GestorDeVida>().Vida / GetComponent<GestorDeVida>().maxVida; //Calculo la vida restante
        Debug.Log("Enemigo- Vida restante: " + vidarestante);
    }

    public void estoyMuertoINSIDE()
    {
        Debug.Log("Enemigo- Estoy muerto");
        if (OnDeathEnemigo != null) //lazo el evento de estar muerto
        {
            OnDeathEnemigo(); //Llamo al evento
        }
        //Create a new enemy at one specific coordinate with the same properties
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(0, 0, 10f), Quaternion.identity); //Instancio un nuevo enemigo
        newEnemy.GetComponent<GestorDeVida>().Vida = newEnemy.GetComponent<GestorDeVida>().maxVida; //Le pongo la vida maxima
        //new enemy scale 3.4,3.4,3.4
        newEnemy.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f); //Le pongo la escala
        Destroy(gameObject); //Destruyo el enemigo actual
    }
}