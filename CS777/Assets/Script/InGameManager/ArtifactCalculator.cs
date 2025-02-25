using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactCalculator : MonoBehaviour
{
    public InGamePlayer ingp;
    public InGameEnemy inge;
    public List<Action> initialFunctionList = new List<Action>();
    private void Start()
    {

    }

   public  void initiatingRelic(List<Relic> relicList)
    {
        foreach(Relic relic in relicList)
        {
            switch(relic.relicIndex)
            {
                case 0:
                    Relic_1();
                    break;
                case 1:
                    Relic_2();
                    break;
                case 2:
                    Relic_3();
                    break;
                case 4:
                    Relic_5();
                    break;
                case 6:
                    Relic_7();
                    break;
                case 5:
                    Relic_6();
                    break;
                case 7:
                    Relic_8();
                    break;

                    
                case 9:
                    Relic_10();
                    break;
                case 12:
                    Relic_13();
                    break;
                case 13:
                    Relic_14();
                    break;
                case 14:
                    Relic_15();
                    break;
                case 15:
                    Relic_16();
                    break;
                case 16:
                    Relic_17();
                    break;
                    default: break;
            }
        }
    }
    public void  Relic_1()
    {
        ingp.powerChange(1);
    }

    public void Relic_2()
    {
        ingp.RobustChange(30);
    }
    public void Relic_3()
    {

    }
    public void Relic_4()
    {
        InGameManager.Instance.nodeVelocity += 40;
    }
    public void Relic_5()
    {

        inge.vulnerableCountChange(5);
    }
    public void Relic_6()
    {
        ingp.breakCountChange(5);
    }
    public void Relic_7()
    {
        InGameManager.Instance.nodeVelocity += 50;
        InGameManager.Instance.timeLimitVelocity += 50;
    }
    public void Relic_8()
    {
        ingp.vulnerableCountChange(5);
        ingp.powerChange(3);
    }
    //public void Relic_9()
    //{
    //    ingp.RobustChange(6);
    //}
    public void Relic_10()
    {
        ingp.breakCountChange(15);
        InGameManager.Instance.timeLimitVelocity += 50;

    }
    public void Relic_11()
    {

    }
    public void Relic_12()
    {

    }
    public void Relic_13()
    {
        InGameManager.Instance.oriTurnTime += 30;
    }
    public void Relic_14()
    {
        InGameManager.Instance.nodeVelocity += 100;
    }

    public void Relic_15()
    {
        ingp.powerChange(2);
    }

    public void Relic_16()
    {
        ingp.powerChange(-2);
        ingp.breakCountChange(30);
    }

    public void Relic_17()
    {
        ingp.RobustChange(100);
    }

}
