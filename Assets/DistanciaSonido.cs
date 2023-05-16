using UnityEngine;

public class DistanciaSonido : MonoBehaviour
{
    public AudioClip clip;  
    public float maxDistance = 10f; 
    public float minVolume = 0.2f; 
    public float maxVolume = 1f;  
    
    private Transform playerTransform;
    private AudioSource audioSource;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Jugador").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        float volume = maxVolume - ((maxVolume - minVolume) * (distanceToPlayer / maxDistance));
        audioSource.volume = volume;
        
        if (distanceToPlayer < maxDistance && !audioSource.isPlaying) 
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        
        if (distanceToPlayer >= maxDistance && audioSource.isPlaying) 
        {
            audioSource.Stop();
        }
    }
}