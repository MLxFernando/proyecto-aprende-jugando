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

    // Referencias para las imágenes
    public Image imagenResultado;    // Objeto Image de UI donde mostrar el resultado
    public Sprite iconoCorrecto;     // Sprite del visto (check verde)
    public Sprite iconoIncorrecto;   // Sprite de la X (equis roja)
    public float tiempoMostrarResultado = 1.5f;  // Tiempo que se mostrará la imagen

    void Start()
    {
        // Asignar la función de revisión a cada botón
        for (int i = 0; i < botones.Count; i++)
        {
            int index = i; // Guardar el índice actual para evitar problemas con la referencia
            botones[i].onClick.AddListener(() => RevisarRespuesta(index));
        }

        // Ocultar la imagen de resultado al inicio si existe
        if (imagenResultado != null)
        {
            imagenResultado.gameObject.SetActive(false);
        }

        // Verificar que el AudioSource esté habilitado
        if (audioSource != null && !audioSource.enabled)
        {
            audioSource.enabled = true;
            Debug.Log("AudioSource habilitado automáticamente");
        }
    }

    void RevisarRespuesta(int indiceSeleccionado)
    {
        bool esCorrecto = (indiceSeleccionado == indiceCorrecto);

        // Mostrar resultado en consola
        Debug.Log(esCorrecto ? "¡Correcto!" : "¡Incorrecto!");

        // Reproducir sonido si el AudioSource está disponible y habilitado
        if (audioSource != null && audioSource.enabled && audioSource.gameObject.activeInHierarchy)
        {
            AudioClip clipAReproducir = esCorrecto ? sonidoCorrecto : sonidoError;
            if (clipAReproducir != null)
            {
                audioSource.PlayOneShot(clipAReproducir);
            }
        }

        // Mostrar imagen de resultado
        MostrarImagenResultado(esCorrecto);
    }

    // Método para mostrar la imagen de resultado
    void MostrarImagenResultado(bool esCorrecto)
    {
        // Verificar que tengamos todas las referencias necesarias
        if (imagenResultado == null)
        {
            Debug.LogWarning("Falta referencia al objeto Image para mostrar el resultado");
            return;
        }

        if (iconoCorrecto == null || iconoIncorrecto == null)
        {
            Debug.LogWarning("Faltan referencias a los sprites de resultado");
            return;
        }

        // Asegurarse de que el objeto padre de la imagen esté activo
        if (!imagenResultado.gameObject.activeInHierarchy)
        {
            Transform parent = imagenResultado.transform.parent;
            if (parent != null)
            {
                parent.gameObject.SetActive(true);
            }
            imagenResultado.gameObject.SetActive(true);
        }

        // Asignar la imagen correcta según el resultado
        imagenResultado.sprite = esCorrecto ? iconoCorrecto : iconoIncorrecto;

        // Mostrar la imagen
        imagenResultado.enabled = true;

        // Ocultar la imagen después del tiempo especificado usando Invoke en lugar de Coroutine
        CancelInvoke("OcultarImagen"); // Cancelar invocaciones previas si existen
        Invoke("OcultarImagen", tiempoMostrarResultado);
    }

    // Método para ocultar la imagen (llamado por Invoke)
    void OcultarImagen()
    {
        if (imagenResultado != null)
        {
            imagenResultado.enabled = false;
        }
    }
}