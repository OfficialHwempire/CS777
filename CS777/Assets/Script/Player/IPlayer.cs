using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    // Start is callinted before the first frame update
    int maxHp{get; }
    int power{get ; }

    int currentHp{get; }
    
    
    void HpChange(int change);
    void powerChange(int change);
    
  
}
