using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instancia;
    private AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantener la música en todas las escenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicados al cambiar de escena
            return;
        }

        audioSource = GetComponent<AudioSource>();
        
        // Asegurar que la música se inicie con un volumen adecuado
        audioSource.volume = 0.09f; // Puedes cambiar este valor entre 0 y 1
        audioSource.Play(); // Reproduce la música al iniciar
    }

    // Método para cambiar el volumen en tiempo real
    public void CambiarVolumen(float volumen)
    {
        audioSource.volume = Mathf.Clamp(volumen, 0f, 1f); // Asegura que esté entre 0 y 1
    }
}


