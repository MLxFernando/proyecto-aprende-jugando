using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RespuestaManager : MonoBehaviour
{
    public AudioSource audioSource;  // Fuente de audio
    public AudioClip sonidoCorrecto; // Sonido cuando acierta
    public AudioClip sonidoError;    // Sonido cuando falla

    public List<Button> botones = new List<Button>(); // Lista de botones a arrastrar manualmente
    public int indiceCorrecto; // Índice del botón que es correcto (0, 1, 2, etc.)

    void Start()
    {
        // Asignar la función de revisión a cada botón
        for (int i = 0; i < botones.Count; i++)
        {
            int index = i; // Guardar el índice actual para evitar problemas con la referencia
            botones[i].onClick.AddListener(() => RevisarRespuesta(index));
        }
    }

    void RevisarRespuesta(int indiceSeleccionado)
    {
        if (indiceSeleccionado == indiceCorrecto)
        {
            Debug.Log("¡Correcto!");
            audioSource.PlayOneShot(sonidoCorrecto);
        }
        else
        {
            Debug.Log("¡Incorrecto!");
            audioSource.PlayOneShot(sonidoError);
        }
    }
}


