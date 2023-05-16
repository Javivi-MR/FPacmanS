using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TratamientosImpactos : MonoBehaviour
{
    //Image barravida;
    float vidarestante;
    public GameObject enemyPrefab;

    public delegate void OnDeath(); //Creo el evento
    public static event OnDeath OnDeathEnemigo; // Indico que función se va encargar de ello

    public void hesidoTocadoINSIDE()
    {
        Debug.Log("Enemigo- Me han tocado");
        //barravida = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        vidarestante = GetComponent<GestorDeVida>().Vida / GetComponent<GestorDeVida>().maxVida;
        //barravida.transform.localScale = new Vector3(vidarestante,1,1);
        Debug.Log("Enemigo- Vida restante: " + vidarestante);
    }

    public void estoyMuertoINSIDE()
    {
        Debug.Log("Enemigo- Estoy muerto");
        if (OnDeathEnemigo != null) //lazo el evento de estar muerto
        {
            OnDeathEnemigo();
        }
        //Create a new enemy at one specific coordinate with the same properties
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(0, 0, 10f), Quaternion.identity);
        newEnemy.GetComponent<GestorDeVida>().Vida = newEnemy.GetComponent<GestorDeVida>().maxVida;
        //new enemy scale 3.4,3.4,3.4
        newEnemy.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f);
        Destroy(gameObject);
    }
}