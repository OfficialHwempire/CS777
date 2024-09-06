using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class NodeInfo
{
    private int startPoint;
    private int endPoint;
    private bool isClick;
    private float nodeSelect = 0;

    private bool nodeFull = false;

    private float bpm = 0.1f;


    public NodeInfo(int start, int end)
    {

        startPoint = start;
        endPoint = end;
    }

    private void nodeIncrement()
    {
        nodeSelect = nodeSelect + bpm;
    }
    private void nodeDecrement()
    {
        nodeSelect = nodeSelect - bpm;
    }

    public void nodeMove()
    {
        if ((nodeSelect > 100) || (nodeSelect < 0))
        {
            Debug.Log(" node point out of range");
            return;
        }
        if (100 > nodeSelect) nodeIncrement();
        else nodeDecrement();
    }
    public bool IsClickSuccess()
    {
        if (nodeFull) return true;
        if ((startPoint < nodeSelect) && (nodeSelect < endPoint)) return true;
        return false;
    }

    public void nodeReset()
    {
        nodeSelect = 0;
    }

}
