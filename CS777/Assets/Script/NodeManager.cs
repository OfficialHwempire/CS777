using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeManager : MonoBehaviour
{

    public List<GameObject> nodeTuneprefabs = new List<GameObject>();
    public List<GameObject> nodeTuneObjects;
    [SerializeField]
    private List<Sprite> nodeSprites = new List<Sprite>();
    private float nodCurrentCount = 0;
    private float speed = 0.5f;
    public static NodeManager instance;
    public Vector2 cardStartPosition;
    public Vector2 cardSpacing;
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
        if (nodCurrentCount > 100)
        {
            nodCurrentCount = 100;
        }
        else if (nodCurrentCount < 100)
        {
            nodCurrentCount += speed * Time.deltaTime;
        }
        foreach (var element in nodeTuneObjects)
        {
            element.transform.localPosition = new Vector2(nodCurrentCount * speed * Time.time, -5);
        }

    }
    void Update()
    {
        nodeMove();
    }

}
