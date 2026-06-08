using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FishEntry
{
    public Fish fishPrefab;
    

    [Range(0f, 100f)]
    public float catchChance = 25f;
    public float HP = 0f;
}

public class FishingArea : MonoBehaviour
{
    private FishEntry currentfish;

    [Header("Fishing Settings")]
    public float waitTime = 5f;

    [Header("Fish List")]
    public List<FishEntry> fishList = new List<FishEntry>();

    [Header("Spawn")]
    public Transform fishSpawnPoint;

    [Header("Float Settings")]
    public float floatSpeed = 2f;
    public float destroyAfterSeconds = 3f;

    private GameObject currentBobber;
    private Coroutine fishingCoroutine;
    public PlayerMovement2 playerMovement2;
    public BattleManager battleManager;
    public PlayerHealth playerHealth;
    public EnemyAI enemyAI;
    public InventoryManager InventoryManager;
    public GameObject AttackButton;
    public GameObject CatchButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bobber"))
        {
            currentBobber = other.gameObject;

            if (fishingCoroutine == null)
            {
                fishingCoroutine = StartCoroutine(FishingRoutine());
            }

            Debug.Log("Dobber in water...");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bobber"))
        {
            currentBobber = null;

            Debug.Log("Dobber uit water");
        }
    }

    IEnumerator FishingRoutine()
    {
        Debug.Log("Wachten op vis...");

        float timer = 0f;
        currentfish = GetRandomFish();
        while (timer < waitTime)
        {
            if (currentBobber == null)
            {
                fishingCoroutine = null;
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        if (currentBobber != null)
        {
            enemyAI.maxHP = (int)currentfish.HP;
            enemyAI.currentHP = (int)currentfish.HP;

            enemyAI.healthBar.SetMaxHP(enemyAI.maxHP);
            enemyAI.healthBar.SetHP(enemyAI.currentHP);

            battleManager.FishingArea = this.gameObject.GetComponent<FishingArea>();
            battleManager.EnemyAI = this.gameObject.GetComponent<EnemyAI>();

            AttackButton.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            AttackButton.gameObject.GetComponent<Button>().onClick.AddListener(AttackButtonFuntion);

            CatchButton.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            CatchButton.gameObject.GetComponent<Button>().onClick.AddListener(CatchButtonFuntion);

            battleManager.isBattleActive = true;
            playerMovement2.canControl = false;
        }

        fishingCoroutine = null;
    }

    private FishEntry GetRandomFish()
    {
        float random = Random.Range(0f, 100f);
        float current = 0f;

        foreach (FishEntry entry in fishList)
        {
            if (entry.fishPrefab == null) continue;

            current += entry.catchChance;

            if (random <= current)
            {
                return entry;
            }
        }

        return null;
    }

    public void Reel()
    {
        int kans = Random.Range(0, 2);

        if (kans == 0)
        {
            CatchFish();
        }
        else
        {
            battleManager.PlayerTurnCompleted(); 
        }
    }
    public void CatchFish()
    {
        if (currentfish == null)
            return;

        Debug.Log("Vis gevangen: " + currentfish.fishPrefab.fishName);

        InventoryManager.AddFish(currentfish.fishPrefab);

        SpawnFish(currentfish.fishPrefab);

        RemoveBobber();

        battleManager.EndBattle();
        playerMovement2.canControl = true;

        currentfish = null;
    }

    void RemoveBobber()
    {
        if (currentBobber != null)
        {
            Destroy(currentBobber);
            currentBobber = null;
            playerMovement2.baitThrown = false;
        }

        Debug.Log("Bobber verwijderd");
    }

    void SpawnFish(Fish fishPrefab)
    {
        if (fishSpawnPoint == null) return;

        GameObject fish = Instantiate(
            fishPrefab.gameObject,
            fishSpawnPoint.position,
            Quaternion.identity
        );

        StartCoroutine(FloatFish(fish));
    }

    IEnumerator FloatFish(GameObject fish)
    {
        float t = 0f;

        while (t < destroyAfterSeconds)
        {
            fish.transform.position += Vector3.up * floatSpeed * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }

        Destroy(fish);
    }

    public void AttackButtonFuntion() 
    {
        playerHealth.Attack(enemyAI);
    }
    public void CatchButtonFuntion()
    {
        playerHealth.TryCatchFish(enemyAI);
    }
}