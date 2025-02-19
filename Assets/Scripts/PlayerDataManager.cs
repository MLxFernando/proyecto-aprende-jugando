using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour{
    public TMP_InputField inputField;

    public TextMeshProUGUI playerNameDisplay;
    public UIManager uiManager; 

    private const string PlayerNameKey = "PlayerName";

    void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            string savedName = PlayerPrefs.GetString(PlayerNameKey);
            if (playerNameDisplay != null)
                playerNameDisplay.text = "Bienvenido, " + savedName;
        }
    }

    public void SavePlayerName()
    {
        string playerName = inputField.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerPrefs.SetString(PlayerNameKey, playerName);
            PlayerPrefs.Save();

            uiManager.ShowPanel(uiManager.panelNiveles);
        }
    }
}
