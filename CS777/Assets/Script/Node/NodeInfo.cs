using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeInfo
{
    private int startPoint;
    private int endPoint;

    public int StartPoint => startPoint;
    public int EndPoint => endPoint;

    public bool isActive = true;



    public NodeInfo(int startPoint, int endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
    public NodeInfo(int cardNodeIndex)
    {
        (this.startPoint, this.endPoint) = cardNodeIndex switch
        {
            0 => (0, 20),
            1 => (20, 40),
            2 => (40, 60),
            3 => (60, 80),
            4 => (80, 100),
            _ => throw new ArgumentException("Invalid cardNodeIndex")
        };
    }


}
