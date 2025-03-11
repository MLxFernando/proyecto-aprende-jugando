using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletionManager : MonoBehaviour
{
    // Referencia al panel de felicitaciones
    public GameObject congratulationsPanel;

    // Lista de colores disponibles en el nivel
    private List<string> availableColors = new List<string>()
    {
        "Naranja", "Rojo", "Verde", "Azul", "Amarrillo", "Morado"
    };

    // Conjunto para rastrear los colores ya presionados
    private HashSet<string> pressedColors = new HashSet<string>();

    void Start()
    {
        // Asegurarse de que el panel de felicitaciones esté oculto al inicio
        congratulationsPanel.SetActive(false);
    }

    // Este método debe ser llamado desde cada botón de color
    public void ColorPressed(string color)
    {
        // Añadir el color a la lista de presionados
        pressedColors.Add(color);

        // Verificar si todos los colores han sido presionados
        CheckCompletion();
    }

    void CheckCompletion()
    {
        // Verificar si todos los colores disponibles han sido presionados
        bool allPressed = true;
        foreach (string color in availableColors)
        {
            if (!pressedColors.Contains(color))
            {
                allPressed = false;
                break;
            }
        }

        // Si todos los colores han sido presionados, mostrar la pantalla de felicitaciones
        if (allPressed)
        {
            ShowCongratulations();
        }
    }

    void ShowCongratulations()
    {
        // Mostrar el panel de felicitaciones
        congratulationsPanel.SetActive(true);
    }

    // Método para reiniciar el nivel
    public void ResetLevel()
    {
        // Limpiar la lista de colores presionados
        pressedColors.Clear();

        // Ocultar el panel de felicitaciones
        congratulationsPanel.SetActive(false);
    }
}