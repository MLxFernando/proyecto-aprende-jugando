using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoNaranja, sonidoRojo, sonidoVerde, sonidoAzul, sonidoAmarillo, sonidoMorado;

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
            case "Naranja":
                sonido = sonidoNaranja;
                break;
            case "Rojo":
                sonido = sonidoRojo;
                break;
            case "Verde":
                sonido = sonidoVerde;
                break;
            case "Azul":
                sonido = sonidoAzul;
                break;
            case "Amarrillo":
                sonido = sonidoAmarillo;
                break;
            case "Morado":
                sonido = sonidoMorado;
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

