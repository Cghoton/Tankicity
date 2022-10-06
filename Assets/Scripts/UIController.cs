using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text messageText;

    [SerializeField]
    private TMP_Text enemiesLeftText;

    [SerializeField]
    private RawImage background;

    void Start()
    {
        
        ClearText();
    }

    void ClearText()
    {
        messageText.text = "";
        background.color = new Color32(255, 255, 255, 0);
    }

    public void SendMessage(string message, string colorName = "white")
    {
        Color32 color;

        switch (colorName)
        {
            case "white":
                color = new Color32(255, 255, 255, 255);
                break;

            case "red":
                color = new Color32(240, 25, 60, 255);
                break;

            case "green":
                color = new Color32(5, 215, 55, 255);
                break;

            case "yellow":
                color = new Color32(255, 230, 35, 255);
                break;

            default:
                color = new Color32(0, 0, 0, 255);
                break;
        }
        background.color = new Color32(255, 255, 255, 67);
        messageText.text = message;
        messageText.color = color;
        Invoke("ClearText", 1f);
    }

    public void UpdateEnemiesAmount(int amount)
    {
        enemiesLeftText.text = "Enemies left: " + amount;
    }
    
}
