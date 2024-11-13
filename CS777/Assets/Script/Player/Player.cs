using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IPlayer
{
    // Start is called before the first frame update
  public int maxHp{get; private set;}
  public int power{get; private set;}

  public int currentHp{get; private set;}

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
}
