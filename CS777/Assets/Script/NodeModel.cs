using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NodeModel : MonoBehaviour
{
    private int startPoint;
    private int endPoint;

    private float nodeSpeed = 500;

    private float currentPoint = 0;
    private int direction = 1;
    public GameObject nodeMarker;
    private GameObject emptyImage;
    public List<GameObject> nodeBackGround;
    public void nodeModel(int startP, int endP, int index)
    {
        startPoint = startP;
        endPoint = endP;
        emptyImage = Instantiate(nodeBackGround[index]);
    }
    void Update()
    {
        Vector3 parentSize = emptyImage.transform.localScale;
        Vector3 relativePosition = nodeMarker.transform.localPosition;

        if (currentPoint == 0 && currentPoint == 100) direction = direction * -1;
        nodeMove(direction);
        currentPoint = (relativePosition.x / parentSize.x) * 100f;

    }
    public void nodeMove(int direction)
    {
        if (direction == 1) nodeMarker.transform.localPosition = Vector3.right * nodeSpeed * Time.deltaTime;
        if (direction == -1) nodeMarker.transform.localPosition = Vector3.left * nodeSpeed * Time.deltaTime;
    }

    public void isClick()
    {
        if (currentPoint < endPoint || currentPoint > startPoint)
        {

        }
    }




}

