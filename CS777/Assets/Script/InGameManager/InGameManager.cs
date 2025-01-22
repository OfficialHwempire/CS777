using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager 
{   public OutGamePlayer player;
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


}
