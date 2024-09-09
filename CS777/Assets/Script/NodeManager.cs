using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private List<NodeInfo> nodLis;

    public static NodeManager instance;

    public static NodeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<NodeManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(NodeManager).Name;
                    instance = go.AddComponent<NodeManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }


    public void nodeLisInitialize(List<NodeInfo> info)
    {
        nodLis = info;
    }

    public void nodeClickInfo(int index, bool isSuccess, List<CardKeyword> cardKeyWordLis)
    {
        if (!isSuccess)
        {
            foreach (var element in nodLis)
            {

            }
        }
    }
    public void CreateNode(int index) { }

}
