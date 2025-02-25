using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic 
{
    // Start is called before the first frame update
    public string RelicName;
    public ArtifactActivationTime ActivationTime;
    public int relicIndex;
    public Relic(string relicName, ArtifactActivationTime activationTime, int relicIndex)
    {
        RelicName = relicName;
        ActivationTime = activationTime;
        this.relicIndex = relicIndex;
    }
    public Sprite LoadRelicSprite(string relicName)
    {
        return Resources.Load<Sprite>($"RelicSprites/{RelicName}");
    }
}
