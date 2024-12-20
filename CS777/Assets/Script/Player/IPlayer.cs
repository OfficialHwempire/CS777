using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    // Start is callinted before the first frame update
    int maxHp{get; }
    int power{get ; }

    int Robust{get;}

    int currentHp{get; }
    int currentPower{get; }
    int shield{get; }
    int weakCount{get; }
    int vulnerableCount {get; }
    int CurrentRobust{get;}    
    
    
    void HpChange(int change);
    void powerChange(int change);
    void shieldChange(int change);
    void weakCountChange(int change);
    void vulnerableCountChange(int change);

    void initialize();
    void RobustChange(int change);    
  
}
