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
        mainPanel.SetActive(false);
        panelRegistro.SetActive(false);
        panelNiveles.SetActive(false);
        
        foreach (var panel in panelesJuego)
        {
            panel.SetActive(false);
        }

        panelToShow.SetActive(true);
    }
}
