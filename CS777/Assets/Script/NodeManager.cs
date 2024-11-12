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
 public float current_count;
 public float max_count = 100;

 public bool is_break;

 public int breakCount;

 public bool is_fever;

 

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


}
