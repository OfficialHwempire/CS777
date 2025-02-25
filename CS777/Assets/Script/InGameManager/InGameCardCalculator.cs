using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor;
using UnityEngine;

public class InGameCardCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public InGamePlayer ingp = null;
    public InGameEnemy inge = null;
    public NodeManager nodeManager;
    public DeckManager deckManager;
    public RelicSlots relicslots;


    public int power = 0;
    public bool isEnemyVulnerable = false;
    
    public int totalDamage = 0;
    public int totalRobust = 0;
    public int totalBreak = 0;
    public float nodeVelocity = 0;
    public int CardPos = 0;
    public int DiscardCount = 0;
    public int powerCount = 0;
    public bool success = true;

    public List<int> cardEffect;


    public void initialize(List<int> effect, bool isSuccess, int cardpos)
    {

        power = ingp.power;
        isEnemyVulnerable = (inge.vulnerableCount
            > 0);
    totalDamage = 0;
    totalRobust = 0;
   totalBreak = 0;
    nodeVelocity = 0;
     CardPos = 0;
    DiscardCount = 0;
     powerCount = 0;
        success = isSuccess;
    cardEffect = effect;
        CardPos = cardpos;
}


    public void action()
    {
        if (!success) return;
        powerCount = powerCountCal();
        totalDamage = damageCal();
        totalRobust = robustCal();
        totalBreak = breakCal();
        nodeVelocity = nodeVelocityCal();
       DiscardCount =discardCountCal();

        powerAction(powerCount);
        velocityAction(nodeVelocity);
        damageAction(totalDamage);
        robustAction(totalRobust);
        if (relicslots.isFourCardExist && InGameManager.Instance.usedcardCount % 4 == 0)
        {
            inge.getDamage(6);
        }
    }
    public int damageCal()
    {
        if (cardEffect[2] == 0) return 0;
       return (cardEffect[2] + power);
    }
    public int robustCal()
    {
        if (cardEffect[1] == 0) return 0;
        return (cardEffect[1]);
    }
    public int breakCal()
    {
        if (cardEffect[0] == 0) return 0;
        return (cardEffect[0]);
    }

    public float nodeVelocityCal()
    {
        if (cardEffect[6]==0) return 0;
        return (cardEffect[6]*0.1f);
    }
    public int discardCountCal()
    {
        if (cardEffect[7] == 0) return 0;
        return cardEffect[7];
    }
    public int powerCountCal()
    {
        if (cardEffect[8]==0) return 0;
        return cardEffect[8];
    }
    public void damageAction(int damage) {
    if(damage ==0) return;
        if (relicslots.isHeaderRelicExist && cardEffect[4] == 1)
        {
            inge.getDamage(damage * 2);
            return;
        }
        if (relicslots.isEndRelicExist && cardEffect[5] == 1)
        {
            inge.getDamage(damage * 2);
            return;
        }
        inge.getDamage
            (damage);
    }
    public void discardAction(int discard) { 
    if(discard ==0) return;
        int remainCard = 0;
        List<int> tempSlots = new List<int>();    
        for(int i=0; i<4; i++)
        {
            if (deckManager.CardSlots[i]==InGameCardSlot.Able)  remainCard++;
            tempSlots.Add(i);
        }
        if (remainCard <= discard)
        {
          foreach(var element in tempSlots)
            {
                deckManager.disCardCard(element);
            } 
          deckManager.totalReset();
        }
        else if (remainCard > discard)
        {
           for(int i=0; i < remainCard; i++)
            {
                deckManager.disCardCard(tempSlots[i]);
            }
        }
    }
    public void breakAction(int  breakCount) { 
    if(breakCount ==0) return;
        ingp.breakCountChange
                (breakCount);
        nodeManager.setNode();
    }
    public void powerAction(int power) {
    if(power ==0) return;   
    if(relicslots.isHeaderRelicExist && cardEffect[4] == 1)
        {
            ingp.powerChange(power * 2);
            return;
        }
        if (relicslots.isEndRelicExist && cardEffect[5] == 1)
        {
            ingp.powerChange(power * 2);
            return;
        }
        ingp.powerChange
            (power);
    }

    public void velocityAction(float velocity) { 
    if(velocity ==0) return;
        if (relicslots.isHeaderRelicExist && cardEffect[4] == 1)
        {
            InGameManager.Instance.nodeVelocity += 2 * velocity;
            return;
        }
        if (relicslots.isEndRelicExist && cardEffect[5] == 1)
        {
            InGameManager.Instance.nodeVelocity += 2 * velocity;
            return;
        }
        InGameManager.Instance.nodeVelocity += velocity;
        nodeManager.changeNodeVelocity();

    }
    public void robustAction(int robust) { 
    if(robust ==0) return;
        if (relicslots.isHeaderRelicExist && cardEffect[4] == 1)
        {
            ingp.RobustChange(robust*2);
            return;
        }
        if (relicslots.isEndRelicExist && cardEffect[5] == 1)
        {
            ingp.RobustChange(robust * 2);
            return;
        }
        ingp.RobustChange(robust);
    }

  
    
}
