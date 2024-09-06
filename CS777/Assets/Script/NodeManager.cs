using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    private List<NodeInfo> nodLis;

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

}
