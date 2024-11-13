using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class cardEffectCalculator 
{
    // Start is called before the fir
    private int totalAttack=0;

    public int TotalAttack =>totalAttack;
    private int basicAttack =0;
    private int totalShield=0;

    private int basicShield=0;

    public int TotalShield => totalShield;

    private int totalBreak;

    public int TotalBreak =>totalBreak;

    private float increaseRate =1.0f;

    private void initialize()
    {
        totalAttack = 0;
        basicAttack = 0;
        totalShield = 0;
        basicShield = 0;
        totalBreak = 0;
        increaseRate = 1.0f;
    }
    public List<int> totalEffectCalculator(Card card)
    {
      initialize();
      foreach(var effect in card.CardEffects){
         switch(effect.getCardKeyword())
         {
             case CardKeyword.Attack:
                 AttackCalculator(effect.getCardEffectValue());
                 break;
             case CardKeyword.Shield:
                 ShieldCalculator(effect.getCardEffectValue());
                 break;
             case CardKeyword.Break:
                 breakCalculator(effect.getCardEffectValue());
                 break;
             case CardKeyword.Head:
                 headCalculator(effect.getCardEffectValue());
                 break;
             case CardKeyword.Tail:
                 tailCalculator(effect.getCardEffectValue());
                 break;
             case CardKeyword.Echo:
                 echoCalculator(effect.getCardEffectValue());
                 break;


      }
      
    }
    totalAttack = (int)(basicAttack * increaseRate);
    totalShield = (int)(basicShield * increaseRate);


      return new List<int>(){totalAttack,totalShield,totalBreak};
      }

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
        increaseRate += 0.1f*(float)cardEffectValue;

     }
     void tailCalculator(int cardEffectValue)
     {
        increaseRate += cardEffectValue;

     }

     void echoCalculator(int cardEffectValue)
     {
       return;

     }
    
}
