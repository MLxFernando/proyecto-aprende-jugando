using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionManager : MonoBehaviour
{
    // Panel que se mostrará cuando se completen todos los colores
    public GameObject panelFinNivelColores;

    // Lista para rastrear qué colores han sido presionados
    private HashSet<string> coloresPresionados = new HashSet<string>();

    // Lista de todos los colores disponibles
    private string[] todosLosColores = { "Naranja", "Rojo", "Verde", "Azul", "Amarrillo", "Morado" };

    void Start()
    {
        // Asegurarnos de que el panel de finalización está oculto al inicio
        panelFinNivelColores.SetActive(false);
    }

    public void RegistrarColorPresionado(string color)
    {
        // Añadir el color a la lista de colores presionados
        coloresPresionados.Add(color);

        // Verificar si todos los colores han sido presionados
        ComprobarTodosColores();
    }

    private void ComprobarTodosColores()
    {
        bool todosPresionados = true;

        // Verificar cada color
        foreach (string color in todosLosColores)
        {
            if (!coloresPresionados.Contains(color))
            {
                todosPresionados = false;
                break;
            }
        }

        // Si todos los colores han sido presionados, mostrar el panel
        if (todosPresionados)
        {
            MostrarPanelFinalizado();
        }
    }

    private void MostrarPanelFinalizado()
    {
        panelFinNivelColores.SetActive(true);
    }

    // Método para reiniciar el nivel (puede ser llamado desde el botón "Aceptar")
    public void ReiniciarNivel()
    {
        coloresPresionados.Clear();
        panelFinNivelColores.SetActive(false);
    }
}