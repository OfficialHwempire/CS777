using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayer : MonoBehaviour

{
    public int maxHp { get; private set; }
    public int power { get; private set; }
    public int vulnerableCount { get; private set; }

    public int breakCount { get; private set; }

    public int currentPower { get; private set; }

    public int currentHp { get; private set; }


    public int CurrentRobust { get; private set; }

    public List<Item> Items { get; private set; }

    public List<InGameCard> playerDeck;

    public void Start()
    {
        maxHp = 100;
        power = 0;
        vulnerableCount = 0;
        currentHp = maxHp;
        currentPower = power;
        CurrentRobust = 0;
        breakCount = 0;
    }

    public void HpChange(int change)
    {
        currentHp += change;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (currentHp <= 0)
        {
            currentHp = 0;
        }
    }

    public void powerChange(int change)
    {
        power += change;
    }


    public void vulnerableCountChange(int change)
    {
        if (vulnerableCount + change < 0)
        {
            vulnerableCount = 0;
            return;
        }
        vulnerableCount += change;
    }
    public void initialize()
    {
        currentHp = maxHp;
        currentPower = power;

    }

    public void RobustChange(int change)
    {

        CurrentRobust += change;
    }

    public void breakCountChange(int change)
    {
        breakCount += change;
    }

    public void getDamage(int Damage)
    {
        int totalDamage = Damage;
        if(vulnerableCount > 0)
        {
            vulnerableCount--;
            totalDamage = Damage * 2;
        }
        if (CurrentRobust

            >= totalDamage) RobustChange
                (-1*totalDamage);
        else
        {
            HpChange(-1 * (totalDamage - CurrentRobust));
            RobustChange
                (-1 * CurrentRobust);
           
        }
    }

}
