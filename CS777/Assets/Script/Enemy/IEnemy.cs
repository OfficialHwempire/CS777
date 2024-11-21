using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    // Start is called before the first frame update
    int maxHp{get; }
    int power{get ; }

    int currentHp{get; }
    int shield{get; }

    int CurrentPower{get;}
    int weakCount{get; }
    int vulnerableCount {get; }
    
    
    void HpChange(int change);
    void powerChange(int change);
    void shieldChange(int change);
    void weakCountChange(int change);
    void vulnerableCountChange(int change);

    List<EnemyPattern> EnemyPatternList{get;}

    void initialize(){

    }

}
