using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChangeArt : MonoBehaviour
{
    public Button turnStartButton;
    public GameObject timeObject;
    public InGameTimeBar timeBar;

    // Update is called once per frame
    void Update()
    {

         if(InGameManager.Instance.turnState== TurnState.playerTurn && InGameManager.Instance.currentTurnTime
            < 0)
        {
            playerTurnToEnemyTurn();
        }
        
    }
    public void EnemyToWaitTurn()
    {
        InGameManager.Instance.turnState = TurnState.waitTurn;
        turnStartButton.gameObject.SetActive(true);
        timeObject.SetActive(false);
    }

    void waitToPlayerTurn()
    {
        turnStartButton.gameObject.SetActive(false);
        timeObject.SetActive(true);
        timeBar.GetHealthSystem().HealComplete();
        InGameManager.Instance.turnState = TurnState.playerTurn;
    }
    public void playerTurnToEnemyTurn()
    {
        timeObject.SetActive(false);
        InGameManager.Instance.currentTurnTime = InGameManager.Instance.oriTurnTime;
        InGameManager.Instance.turnState = TurnState.enemyTurn;
    }
}
