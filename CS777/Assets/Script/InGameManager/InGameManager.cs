using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InGameManager 
{   public OutGamePlayer player;
    public TurnState turnState;
   
    private OutGamePlayer Player => player;
    private static InGameManager instance;
    public static InGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InGameManager();
            }
            return instance;
        }
    }

    private InGameManager()
    {
        // 게임 시작 시 필요한 초기화 작업을 수행합니다.
        

    }
    public InGamePlayer ingp;
    public InGameEnemy inge;
    public float nodeVelocity;
    public float timeLimitVelocity=0;
    public int currentStage = 0;
    public void discardAction(int discardCount) { }

    public bool isinputAble = false;

    public float oriTurnTime = 60f;
    public float currentTurnTime = 60f;
    public int usedcardCount = 0;

    public List<Relic> Relics;






}
