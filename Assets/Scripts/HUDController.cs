using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI modeText;
    private PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        if (player == null) return;
        modeText.text = player.isStealth ? "STEALTH" : "NORMAL";
        modeText.color = player.isStealth
            ? new Color(0.11f, 0.62f, 0.46f)
            : new Color(0.96f, 0.94f, 0.91f);
    }
}