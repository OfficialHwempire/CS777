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
        // ���� �̵� �� �ٽ� ���� ��ġ�� ���ƿ��� �ִϸ��̼�
        await inge.gameObject.transform.DOMoveY(transform.position.y + moveDistance, duration)
       .SetEase(Ease.InOutSine)
       .AsyncWaitForCompletion(); // �ִϸ��̼��� ���� ������ ���

        // ���� ��ġ�� �̵�
        await inge.gameObject.transform.DOMoveY(transform.position.y, duration)
            .SetEase(Ease.InOutSine)
            .AsyncWaitForCompletion();
    }

    
}
