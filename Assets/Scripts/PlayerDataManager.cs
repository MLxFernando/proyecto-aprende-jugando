using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerDataManager : MonoBehaviour
{
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
        string playerName = inputField.text.Trim(); // Elimina espacios en blanco al inicio y al final
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("El nombre del jugador está vacío. Introduce un nombre válido.");
            return;
        }

        PlayerPrefs.SetString(PlayerNameKey, playerName);
        PlayerPrefs.Save();

        if (playerNameDisplay != null)
            playerNameDisplay.text = "Bienvenido, " + playerName;

        if (uiManager != null)
        {
            uiManager.ShowPanel(uiManager.panelNiveles);
        }
        else
        {
            Debug.LogError("UIManager no está asignado en PlayerDataManager.");
        }
    }
}
