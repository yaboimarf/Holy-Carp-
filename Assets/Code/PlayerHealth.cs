using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public int attackDamage = 25;
    public int HeavyAttackDamage = 50;

    public HealthBar healthBar;
    public BattleManager battleManager;

    public bool TurnCooldown;

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

    public void Heal(EnemyAI enemy)
    {
        currentHP += 50; 

        if (currentHP > maxHP)
            currentHP = maxHP;

        healthBar.SetHP(currentHP);
        battleManager.PlayerTurnCompleted();
    }
    
    public void HeavyAttack(EnemyAI enemy)
    { 
        enemy.TakeHeavyDamage(HeavyAttackDamage);
        TurnCooldown = true;
        battleManager.PlayerTurnCompleted();
    }
}