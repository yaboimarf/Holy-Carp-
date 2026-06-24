using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money;
    public int prijs;
    public TMP_Text moneyText;
    public GameObject winScreen;
    public GameObject ShopCanvas;
    public PlayerMovement2 playerMovement;


    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }
    public void UpdateUI()
    {
        moneyText.text = "€ " + money;
    }
    public void Wins()
    {
        if (money >= prijs)
        {
            winScreen.gameObject.SetActive(true);
            ShopCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.canControl = false;
        }
    }
}