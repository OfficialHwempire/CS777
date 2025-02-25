using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private static NodeManager instance;
        public static NodeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NodeManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("NodeManager");
                    instance = obj.AddComponent<NodeManager>();
                }
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    public List<GameObject> nodePrefabs;
    public List<PendulumMoveController> moveControllers;
    public void setNode() { 
            InGamePlayer ingp = FindAnyObjectByType<InGamePlayer>();
        if (ingp.breakCount > 0)
        {
            foreach(GameObject node in nodePrefabs)
            {
                SpriteRenderer spr = node.GetComponent<SpriteRenderer>();
                spr.sprite = LoadNodeSprite(4);
            }
        }
        else {
    for(int i = 0; i < 4; i++)
        {
                SpriteRenderer spr = nodePrefabs[i].GetComponent<SpriteRenderer>(); 
                spr.sprite = LoadNodeSprite(DeckManager.Instance.InGameHand[i].NodeType);
        }
        }
    }

 

  void Awake()
    {
        // 싱글톤 인스턴스 초기화
        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스가 생성되지 않도록 파괴
        }
    }

    private Sprite LoadNodeSprite(int nodeindex)
    {
        // 카드 이름에 따라 스프라이트를 Resources 폴더에서 불러옵니다.
        return Resources.Load<Sprite>($"NodeSprites/{nodeindex}");
    }
    public void changeNodeVelocity()
    {
        float totalNodeVelocity = InGameManager.Instance.nodeVelocity;
        foreach(var pendulum in moveControllers)
        {
            pendulum.nodeSpeed = totalNodeVelocity;
        }
    }
}
