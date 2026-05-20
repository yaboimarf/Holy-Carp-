using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public bool isBattleActive;
    public bool playerTurnDone;
    public bool enemyTurnDone;
    public GameObject battleMenu;
    public FishingArea FishingArea;
    private void Update()
    {
        if (isBattleActive)
        {
            StartBattle();
        }
    }

    public void StartBattle()
    {
        battleMenu.SetActive(true);
        Debug.Log("player turn");
        if (playerTurnDone)
        {
            battleMenu.SetActive(false);
            Debug.Log("enemy turn");

            if (enemyTurnDone)
            {
                playerTurnDone = false;
                enemyTurnDone = false;
            }
        }
    }
    public void PlayerTurnCompleted()
    {
        playerTurnDone = true;
    }
    public void EnemyTurnCompleted()
    {
        if (playerTurnDone)
        {
            enemyTurnDone = true;
        }
    }
    public void EndBattle()
    {
        isBattleActive = false;
        playerTurnDone = false;
        enemyTurnDone = false;
        battleMenu.SetActive(false);
    }
}
