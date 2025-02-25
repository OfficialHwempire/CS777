using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InGameEnemy :MonoBehaviour

{

    public InGamePlayer ingp;
    public string enemyName { get; private set; }
    public int maxHp { get; private set; }
    public int vulnerableCount { get; private set; }
    public int currentHp { get; private set; }

    public int CurrentPower { get; private set; }

    public int currentRobust { get; private set; }


    public InGameEnemy(string name, int hp)
    {
        enemyName = name;
        maxHp = hp;
        currentHp = hp;
        vulnerableCount = 0;
        CurrentPower = 0;
        currentRobust = 0;
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
        CurrentPower += change;
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

    public void getDamage(int Damage)
    {
        int totalDamage = Damage;
        if (vulnerableCount > 0)
        {
            vulnerableCount--;
            totalDamage = Damage * 2;
        }
        if (currentRobust

            >= totalDamage) robustChange
                (-1 * totalDamage);
        else
        {
            HpChange(-1 * (totalDamage - currentRobust));
            robustChange
                (-1 * currentRobust);

        }
    }

    public void robustChange(int change)
    {
        currentRobust += change;
    }
    public void attack(int attack)
    {
        int totalDamage = attack + CurrentPower;
        ingp.getDamage(totalDamage);

    }
    public abstract void pattern1();

    public abstract void pattern2();



}
