using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDTO
{
    public int Index { get; set; }

    public bool IsClick { get; set; }

    public ClickDTO(int index, bool isClick)
    {
        Index = index;
        IsClick = isClick;

    }
}
