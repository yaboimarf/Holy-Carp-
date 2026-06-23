using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money;
    public TMP_Text moneyText;

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }
    public void UpdateUI()
    {
        moneyText.text = "€ " + money;
    }
}