using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject panelRegistro;
    public GameObject panelNiveles;
    public GameObject[] panelesJuego;

    private bool isTransitioning = false; // Bandera para evitar múltiples llamadas seguidas

    void Start()
    {
        ShowPanel(mainPanel);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        if (!isTransitioning) 
        {
            StartCoroutine(ShowPanelWithDelay(panelToShow)); // Inicia la espera
        }
    }

    IEnumerator ShowPanelWithDelay(GameObject panelToShow)
    {
        isTransitioning = true; // Bloquea llamadas adicionales

        yield return new WaitForSeconds(1.1f); // Espera 2 segundos antes de cambiar de panel

        // Oculta todos los paneles
        mainPanel.SetActive(false);
        panelRegistro.SetActive(false);
        panelNiveles.SetActive(false);
        
        foreach (var panel in panelesJuego)
        {
            panel.SetActive(false);
        }

        // Muestra el nuevo panel
        panelToShow.SetActive(true);

        isTransitioning = false; // Permite nuevas transiciones
    }
}
