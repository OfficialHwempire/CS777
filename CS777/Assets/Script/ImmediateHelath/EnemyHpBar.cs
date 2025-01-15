using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;
public class EnemyHpBar : MonoBehaviour,IGetHealthSystem
{
    private HealthSystem healthSystem;
    // Start is called before the first frame update
        private void Awake()
    {
        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
    }

    // Update is called once per frame

        private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
       Debug.Log("Enemy Dead");
    }
    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
    }
        public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

}
