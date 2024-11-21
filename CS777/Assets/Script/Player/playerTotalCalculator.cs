using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTotalCalculator 
{

    public Player player;
  public int CalculateHpChange(int attack){

    return player.currentPower + attack;
   }
   public int CalculateShieldChange(int shield){

    return player.CurrentRobust + shield;
   }
   

   
}
