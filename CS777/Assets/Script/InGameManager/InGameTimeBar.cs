using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTimeBar : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthSystem healthSystem;



    private void Awake()
    {
        float totalTime = InGameManager.Instance.oriTurnTime;
        healthSystem = new HealthSystem(totalTime);
    }
    // Start is called before the first frame update
    private void Update()
    {
       healthSystem.SetHealth(InGameManager.Instance.currentTurnTime);
      //  healthSystem.Damage(Time.deltaTime*((100+ InGameManager.Instance.timeLimitVelocity))/100);
        InGameManager.Instance.currentTurnTime -= (Time.deltaTime * ((100 + InGameManager.Instance.timeLimitVelocity)) / 100);
    }

    //public void FailDamage()
    //{
    //    healthSystem.Damage(5);
    //}
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
    // Update is called once per frame
}
