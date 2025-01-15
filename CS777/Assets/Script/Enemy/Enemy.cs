using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    // Start is called before the first frame update
    public int maxHp{get; private set;}
    public int power{get; private set;}
    public int shield{get; private set;}
    public int weakCount{get; private set;}
    public int vulnerableCount{get; private set;}
    public int currentHp{get; private set;}

    public int CurrentPower{get; private set;}

    public List<EnemyPattern> EnemyPatternList{get; private set;}
    
    void Start()
    {
        maxHp = 100;
        power = 0;
        shield = 0;
        weakCount = 0;
        vulnerableCount = 0;
        currentHp = maxHp;
        CurrentPower = power;
    }
    public void HpChange(int change){

        currentHp += change;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if(currentHp<=0)
        {
            currentHp = 0;
        }
    }
    public void powerChange(int change){
        currentHp += change;
    }

    public void shieldChange(int change){
        if(shield + change < 0){
            shield = 0;
            return;
        }
        shield += change;
    }
    public void vulnerableCountChange(int change){
        if(vulnerableCount + change < 0){
            vulnerableCount = 0;
            return;
        }
        vulnerableCount += change;
    }
    public void weakCountChange(int change){
        if(weakCount + change < 0){
            weakCount = 0;
            return;
        }
        weakCount += change;
    }
    public void initialize()
    {
        currentHp = maxHp;
        CurrentPower = power;

    }



}
