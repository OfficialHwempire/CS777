using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public List<GameObject> nodeTuneprefabs = new List<GameObject>();
    public List<GameObject> nodeTuneObjects;

    public List<NodeInfo> nodeInfos = new List<NodeInfo>();
    [SerializeField]
    private List<Sprite> nodeSprites = new List<Sprite>();
    private float nodCurrentCount = 0;
    private float speed = 0.5f;
    public static NodeManager instance;
    public Vector2 cardStartPosition;
    public Vector2 cardSpacing;
    public int nodeBreakPoint = 0;
    public bool isBreak => nodeBreakPoint > 0;

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
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void CreateNode(int index, Card card)
    {

        GameObject nodeObject = new GameObject("Node" + index);

        nodeObject.AddComponent<SpriteRenderer>().sprite = nodeSprites[card.CardSpirteIndex];
        nodeInfos.Add(new NodeInfo(card.CardNodeIndex));
        Vector2 nodePosition = cardStartPosition + index * cardSpacing;
        nodeObject.transform.localPosition = nodePosition;

        GameObject nodeTuneObject = Instantiate(nodeTuneprefabs[card.CardNodeIndex], nodeObject.transform);
        nodeTuneObjects.Add(nodeTuneObject);
        nodeTuneObject.transform.localPosition = new Vector2(0, -5);


    }
    public void nodeMove()
    {

        if (nodCurrentCount < 0)
        {
            nodCurrentCount = 0;
        }
        else if (nodCurrentCount > 100)
        {
            nodCurrentCount = 100;
        }
        else if (nodCurrentCount <= 100)
        {
            nodCurrentCount += speed * Time.deltaTime;
        }
        Vector2 currentNodePostion = new Vector2(nodCurrentCount, 0);
        nodePositionChange(currentNodePostion);
        // foreach (var element in nodeTuneObjects)
        // {
        //     element.transform.localPosition = new Vector2(nodCurrentCount * speed * Time.time, -5);
        // }

    }
    void start()
    {
        nodCurrentCount = 0;

    }

    void Update()
    {
        nodeMove();
    }

    public void nodePositionChange(Vector2 position)
    {
        foreach (var element in nodeTuneObjects)
        {
            element.transform.localPosition = position;
        }
    }

    public void SuccessNode(int cardIndex)
    {
        if (isBreak)
        {
            UnityEngine.Debug.Log("Break is active");
            nodCurrentCount = 0;
            nodeBreakPoint--;

        }
        UnityEngine.Debug.Log("Success, cardIndex is " + cardIndex);

        nodCurrentCount = 0;
        nodeInfos[cardIndex].isActive = false;

    }
    public void FailNode(int cardIndex)
    {
        UnityEngine.Debug.Log("Fail, cardIndex is " + cardIndex);
        nodCurrentCount = 0;

    }

    public bool isNodeInputTrue(int cardIndex)
    {
        if (isBreak) return true;
        return (nodCurrentCount < (float)nodeInfos[cardIndex].EndPoint && nodCurrentCount > (float)nodeInfos[cardIndex].StartPoint);
    }

    public void breakTimeExecution()
    {
        nodeBreakPoint++;
        nodCurrentCount = 0;

        foreach (var element in nodeTuneObjects)
        {
            element.GetComponent<SpriteRenderer>().sprite = nodeSprites[6];//break sprite would be 6

        }
    }



}
