using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAnimacion : MonoBehaviour
{
    public AudioClip audioClip;
    public Animation animacion;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            animacion.wrapMode = WrapMode.Once;
            animacion.Play();
        }
    }
}