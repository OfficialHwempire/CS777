using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameCardObj : MonoBehaviour
{
    // Start is called before the first frame update
    public InGameCard card;
    public int cardSlotNum;
    public Vector2 slotPos;
   
    public void setSprite(string spriteName)
    {
        SpriteRenderer spr = this.GetComponent<SpriteRenderer>();
        spr.sprite = Resources.Load<Sprite>($"CardSprites/{spriteName}");
    }
}
