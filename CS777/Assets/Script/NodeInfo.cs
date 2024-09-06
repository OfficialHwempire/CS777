using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private int startPoint;
    private int endPoint;

    private float nodeSelect = 0;

    private float bpm = 1;


    public Node(int start, int end)
    {

        startPoint = start;
        endPoint = end;
    }

    public void nodeIncrement()
    {
        nodeSelect = nodeSelect + bpm;
    }
    public void nodeDecrement()
    {
        nodeSelect = nodeSelect - bpm;
    }

}
