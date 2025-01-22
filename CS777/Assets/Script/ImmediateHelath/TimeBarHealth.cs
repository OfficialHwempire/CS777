using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.HealthSystemCM;
using UnityEngine;


   public class TimeBarHealth : MonoBehaviour,IGetHealthSystem
{
    private HealthSystem healthSystem;
    

    private void Awake()
    {
        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
    }
    // Start is called before the first frame update
    private void Update()
    {
        healthSystem.Damage(Time.deltaTime);
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
    //    Debug.Log("Dead");
    }

    public void FailDamage()
    {
        healthSystem.Damage(5);
    }
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
    // Update is called once per frame
    
}


