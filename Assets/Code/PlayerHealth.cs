using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public int attackDamage = 25;

    public HealthBar healthBar;
    public BattleManager battleManager;

    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHP(maxHP);
    }

    public void ResetHP()
    {
        currentHP = maxHP;
        healthBar.SetHP(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        healthBar.SetHP(currentHP);

        if (currentHP <= 0)
        {
            battleManager.EndBattle();
        }
    }

    public void Attack(EnemyAI enemy)
    {
        enemy.TakeDamage(attackDamage);
        battleManager.PlayerTurnCompleted();
    }

    public void TryCatchFish(EnemyAI enemy)
    {
        float hpPercentage = (float)enemy.currentHP / enemy.maxHP;

        float catchChance = (1f - hpPercentage) * 75f;

        float roll = Random.Range(0f, 100f);

        if (roll <= catchChance)
        {
            enemy.fishingArea.CatchFish();
        }
        else
        {
            battleManager.PlayerTurnCompleted();
        }
    }
}