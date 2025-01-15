using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class totalManager : MonoBehaviour 
{
    // Start is called before the first frame updat
    public GameObject playerObect;
    public Player player;
    public Enemy enemy;
    public GameObject enemyObject;

    public PlayerHpBar playerHpBar;
    public EnemyHpBar enemyHpBar;

    public TimeBarHealth timeBarHealth;

    playerTotalCalculator playerTotalCalculator = new playerTotalCalculator();
    public InGameInputManager inGameInputManager;

    public PendulumMoveController pendulumMoveController;

    void Start()
    {
        inGameInputManager.pendulumMoveController = pendulumMoveController;
        inGameInputManager.totalManager = this;

    }
   public void timeBarHealthChange(){
       timeBarHealth.FailDamage();
   }
    void PlayerHpChange(int change){
        player.HpChange(change);
        playerHpBar.Damage(-change);
    }
    void PlayerShieldChange(int change){
        player.shieldChange(change);    
    }

    void PlayerPowerChange(int change){
        player.powerChange(change);
    }

    void playerWeakCountChange(int change){
        player.weakCountChange(change);
    }
    void vulnerableCountChange(int change){
        player.vulnerableCountChange(change);
    }
    void EnemyHpChange(int change){
        enemy.HpChange(change);
        enemyHpBar.Damage(-change);
    }

    void EnemyShieldChange(int change){
        enemy.shieldChange(change);
    }

    void EnemyPowerChange(int change){
        enemy.powerChange(change);
    }

    void EnemyWeakCountChange(int change){
        enemy.weakCountChange(change);
    }
 
    void EnemyVulnerableCountChange(int change){
        enemy.vulnerableCountChange(change);
    }
    void playerAttackAction (Player _player, Enemy _enemy, int attackValue){
        int inputAttack= playerTotalCalculator.CalculateHpChange(attackValue);
        if(player.weakCount>0){
            inputAttack = inputAttack *(1/2);
        }
        if(enemy.vulnerableCount>0){
            inputAttack = inputAttack *2;
        }
        int totalPoint = inputAttack - _enemy.shield;
        
        if(totalPoint > 0){
            EnemyHpChange(-totalPoint);
        }
        else{
            EnemyShieldChange(totalPoint);
        }
    }

    void enemyAttackAction (Player _player, Enemy _enemy, int attackValue){
        int inputAttack= playerTotalCalculator.CalculateHpChange(attackValue);
        if(enemy.weakCount>0){
            inputAttack = inputAttack *(1/2);
        }
        if(player.vulnerableCount>0){
            inputAttack = inputAttack *2;
        }
        int totalPoint = inputAttack - _player.shield;
        
        if(totalPoint > 0){
            PlayerHpChange(-totalPoint);
        }
        else{
            PlayerShieldChange(totalPoint);
        }
        

  
    
 }
}
