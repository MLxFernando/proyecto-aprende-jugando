using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject panelRegistro;
    public GameObject panelNiveles;
    public GameObject[] panelesJuego;

    void Start()
    {
        ShowPanel(mainPanel);
    }

    public void ShowPanel(GameObject panelToShow)
    {
        StartCoroutine(SwitchPanelWithDelay(panelToShow, 2f));
    }

    private IEnumerator SwitchPanelWithDelay(GameObject panelToShow, float delay)
    {
        // Mantiene el panel actual visible por el tiempo de delay
        yield return new WaitForSeconds(delay);

        // Oculta todos los paneles
        mainPanel.SetActive(false);
        panelRegistro.SetActive(false);
        panelNiveles.SetActive(false);

        foreach (var panel in panelesJuego)
        {
            panel.SetActive(false);
        }

        // Muestra el nuevo panel después del delay
        panelToShow.SetActive(true);
    }
}
