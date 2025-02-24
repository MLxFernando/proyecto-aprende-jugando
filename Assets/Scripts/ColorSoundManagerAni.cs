using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSoundManagerAni : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoPerro, sonidoGato, sonidoVaca, sonidoCerdo, sonidoCaballo, sonidoPato;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public void ReproducirSonido(string color)
    {
        AudioClip sonido = null;

        switch (color)
        {
            case "Perro":
                sonido = sonidoPerro;
                break;
            case "Gato":
                sonido = sonidoGato;
                break;
            case "Vaca":
                sonido = sonidoVaca;
                break;
            case "Cerdo":
                sonido = sonidoCerdo;
                break;
            case "Caballo":
                sonido = sonidoCaballo;
                break;
            case "Pato":
                sonido = sonidoPato;
                break;
        }

        if (sonido != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonido);
        }
        else
        {
            Debug.LogWarning("No se encontró el sonido o el AudioSource en " + color);
        }
    }
}

