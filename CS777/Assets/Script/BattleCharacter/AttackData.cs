using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class AttackData : MonoBehaviour
{
    public string sourceName;
    public string targetName;

    public int damage;

    public List<DebufData> debufDataList;

}
