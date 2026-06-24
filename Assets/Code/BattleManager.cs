using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public bool isBattleActive;
    public bool playerTurnDone;
    public bool enemyTurnDone;

    public GameObject battleMenu;
    public GameObject HealthBarCanvas;
    public GameObject InventoryCanvas;
    public GameObject Canvas;

    public FishingArea FishingArea;
    public EnemyAI EnemyAI;
    public PlayerHealth playerHealth;
    public PlayerMovement2 playerMovement2;
    public GameObject battleLocation;
    public GameObject ogCamLocation;

    private void Update()
    {
        if (!isBattleActive)
            return;

        StartBattle();
    }

    public void StartBattle()
    {
        if (!isBattleActive)
            return;

        battleMenu.SetActive(true);
        HealthBarCanvas.SetActive(true);
        InventoryCanvas.SetActive(false);
        Canvas.SetActive(false);
        playerMovement2.cam.transform.position = battleLocation.transform.position;
        playerMovement2.cam.transform.rotation = battleLocation.transform.rotation;

        FishingArea.SpawnFish(FishingArea.currentfish.fishPrefab);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("player turn");

        if (playerTurnDone)
        {
            battleMenu.SetActive(false);

            Debug.Log("enemy turn");

            if (enemyTurnDone)
            {
                if (playerHealth.TurnCooldown)
                {
                    playerHealth.TurnCooldown = false;
                    enemyTurnDone = false;
                    EnemyAI.EnemyTurn(playerHealth);
                }
                else
                {
                    playerTurnDone = false;
                    enemyTurnDone = false;
                }
            }
        }
    }

    public void PlayerTurnCompleted()
    {
        if (!isBattleActive)
            return;        
           
        playerTurnDone = true;
            EnemyAI.EnemyTurn(playerHealth);      
   
    }

    public void EnemyTurnCompleted()
    {
        if (!isBattleActive)
            return;



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
        HealthBarCanvas.SetActive(false);
        Canvas.SetActive(true);
        playerMovement2.cam.transform.position = ogCamLocation.transform.position;
        playerMovement2.cam.transform.rotation = ogCamLocation.transform.rotation;

        playerHealth.ResetHP();
        EnemyAI.ResetHP();
        FishingArea.FishSpawned = false;
        Transform child = FishingArea.fishSpawnPoint.transform.GetChild(0);
        Destroy(child.gameObject);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}