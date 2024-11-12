using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardEffectCalculator 
{
    // Start is called before the fir
    private int totalAttack=0;
    private int basicAttack =0;
    private int totalShield=0;

    private int basicShield=0;

    private int totalBreak;

    private float increaseRate =1.0f;

     void AttackCalculator(int cardEffectValue)
     {
        basicAttack += cardEffectValue;

     }
     void ShieldCalculator(int cardEffectValue)
     {
        basicShield += cardEffectValue;

     }

     void breakCalculator(int cardEffectValue)
     {
        totalBreak += cardEffectValue;

     }
     void headCalculator(int cardEffectValue)
     {
        increaseRate += cardEffectValue;

     }
     void tailCalculator(int cardEffectValue)
     {
        increaseRate += cardEffectValue;

     }

     void echoCalculator(int cardEffectValue)
     {
       

     }
    
}
