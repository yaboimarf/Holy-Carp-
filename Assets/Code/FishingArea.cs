using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FishEntry
{
    public Fish fishPrefab;
    

    [Range(0f, 100f)]
    public float catchChance = 25f;
}

public class FishingArea : MonoBehaviour
{
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
            playerHealth.ResetHP();
            enemyAI.ResetHP();
            battleManager.isBattleActive = true;
        }

        fishingCoroutine = null;
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
        float random = Random.Range(0f, 100f);
        float current = 0f;

        foreach (FishEntry entry in fishList)
        {
            if (entry.fishPrefab == null) continue;

            current += entry.catchChance;

            if (random <= current)
            {
                Debug.Log("Vis gevangen: " + entry.fishPrefab.fishName);

                SpawnFish(entry.fishPrefab);

                // HIER: bobber verwijderen
                RemoveBobber();

                battleManager.EndBattle();             

                return;
            }
        }

        Debug.Log("Geen vis gevangen");
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
}