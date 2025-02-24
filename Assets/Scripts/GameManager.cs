using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject[] gamePanels; // Paneles del juego

    private int currentPanelIndex = 0;



    void Start()
    {
        SetupCurrentPanel();
    }


    void SetupCurrentPanel()
    {
        // Desactiva todos los paneles y activa solo el actual
        for (int i = 0; i < gamePanels.Length; i++)
        {
            gamePanels[i].SetActive(i == currentPanelIndex);
        }

    }


    void MoveToNextPanel()
    {
        if (currentPanelIndex < gamePanels.Length - 1)
        {
            currentPanelIndex++;
            SetupCurrentPanel();
        }
        else
        {
            Debug.Log("¡Juego terminado!");

        }
    }
}

