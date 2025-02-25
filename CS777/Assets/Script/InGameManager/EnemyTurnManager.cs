using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTurnManager : MonoBehaviour
{
    public float moveDistance = 2f;
    public float duration = 1f;
    public InGameEnemy inge;
    public InGamePlayer ingp;
    public TurnChangeArt turnChangeArt;

    // Update is called once per frame
   async void  Update()
    {
        if (InGameManager.Instance.turnState == TurnState.enemyTurn)
        {

         
            await enemyAnimation();
            inge.pattern1();
            turnChangeArt.EnemyToWaitTurn();


        }

    }

    async Task enemyAnimation()
    {
        // 위로 이동 후 다시 원래 위치로 돌아오는 애니메이션
        await inge.gameObject.transform.DOMoveY(transform.position.y + moveDistance, duration)
       .SetEase(Ease.InOutSine)
       .AsyncWaitForCompletion(); // 애니메이션이 끝날 때까지 대기

        // 원래 위치로 이동
        await inge.gameObject.transform.DOMoveY(transform.position.y, duration)
            .SetEase(Ease.InOutSine)
            .AsyncWaitForCompletion();
    }

    
}
