using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IPlayer
{
    // Start is called before the first frame update
  public int maxHp{get; private set;}
  public int power{get; private set;}
  public int shield{get; private set;}  
  public int weakCount{get; private set;}
  public int vulnerableCount{get; private set;}

  public int currentPower{get; private set;}

  public int currentHp{get; private set;}

  public int Robust{get; private set;}

  public int CurrentRobust{get; private set;}

  public void Start()
  {
      maxHp = 100;
      power = 0;
      shield = 0;
      weakCount = 0;
      vulnerableCount = 0;
      currentHp = maxHp;
      currentPower = power;
      Robust = 0;
      CurrentRobust = Robust;
  }

  public void HpChange(int change)
  {
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

  public void powerChange(int change)
  {
      power += change;
  }

  public void shieldChange(int change)
  {
    if(shield + change < 0){
        shield = 0;
        return;
    }
      shield += change;
  }
  public void weakCountChange(int change)
  {
    if(weakCount + change<0){
        weakCount = 0;
        return;
    }
      weakCount += change;
  }

  public void vulnerableCountChange(int change){
    if(vulnerableCount + change < 0){
        vulnerableCount = 0;
        return;
    }
    vulnerableCount += change;
  }
  public void initialize(){
    currentHp = maxHp;
    currentPower = power;

  }

  public void RobustChange(int change){

    Robust += change;
  }
}
