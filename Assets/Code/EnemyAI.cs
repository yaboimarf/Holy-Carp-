using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public int maxHP = 100;
    public int currentHP;
    
    public int attackDamage = 25;
   
    public HealthBar healthBar;
    public FishingArea fishingArea;
    public BattleManager battleManager;
    public PlayerHealth player;

    void Start()
    {
        currentHP = maxHP;

        healthBar.SetMaxHP(maxHP);
    }

    public void ResetHP()
    {
        currentHP = maxHP;
        healthBar.SetMaxHP(maxHP);
    }
    public void EnemyTurn(PlayerHealth player)
    {
        StartCoroutine(EnemyTurnDelay(player));
    }

    IEnumerator EnemyTurnDelay(PlayerHealth player)
    {
        yield return new WaitForSeconds(1.5f);

        if (currentHP < maxHP / 3)
        {
            int keuze = Random.Range(0, 2);

            if (keuze == 0)
            {
                Heal();
            }
            else
            {
                Attack(player);
            }
        }
        else
        {
            Attack(player);
        }

        battleManager.EnemyTurnCompleted();
    }


    public void Attack(PlayerHealth player)
    {

        player.TakeDamage(attackDamage);
    }

    void Heal()
    {

        currentHP += 15;

        if (currentHP > maxHP)
            currentHP = maxHP;

        healthBar.SetHP(currentHP);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        healthBar.SetHP(currentHP);


        if (currentHP <= 0)
        {
            fishingArea.CatchFish();
        }
    }

}