using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum nodeRange
    {

        normal,
        full
    }
    private List<NodeInfo> nodeLis;

    public void startNode()
    {
        StartCoroutine(nodeMoveCoroutine());

    }
    IEnumerator nodeMoveCoroutine()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            foreach (var element in nodeLis)
            {
                element.nodeMove();
            }
        }
    }
    public void createNodePrefab()
    {

    }

    public void stopNode()
    {
        foreach (var element in nodeLis)
        {
            element.nodeReset();
        }
    }

    public void nodeKeyword(nodeRange nodeState)
    {

    }

    public void success()
    {

    }
}
