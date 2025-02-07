using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainPanel : MonoBehaviour
{
    [Header("PanelRegistro")]
    public Slider inpNombre;
    public Slider btnIncio;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject panelRegistro;
    public GameObject panelNiveles;

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        panelRegistro.SetActive(false);
        panelNiveles.SetActive(false);

        panel.SetActive(true);
    }

}
