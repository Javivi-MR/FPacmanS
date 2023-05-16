using UnityEngine;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour {
    public Transform player;
    public RawImage mapImage;

    void Update() {
        // Calcula la posición del jugador en la imagen del mapa
        Vector2 mapPos = new Vector2(player.position.x / mapImage.rectTransform.rect.width,
                                     player.position.z / mapImage.rectTransform.rect.height);

        // Actualiza la posición del punto amarillo en la imagen del mapa
        mapImage.rectTransform.anchorMin = mapPos;
        mapImage.rectTransform.anchorMax = mapPos;
    }
}