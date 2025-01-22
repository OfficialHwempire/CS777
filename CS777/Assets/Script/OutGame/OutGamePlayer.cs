using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutGamePlayer 
{

public string playerName;
public int playerMaxHp;
public List<Card> playerDeck;
public List<Item> playerItems;

public List<Passive> playerPassives; 



public string playerArt;

public OutGamePlayer(string playerName = "hwempire", int playerMaxHp =100)
{
    this.playerName = playerName;
    this.playerMaxHp = playerMaxHp;


}

public void AddCard(Card card)
{
    playerDeck.Add(card);
}

public void RemoveCard(Card card)
{
    playerDeck.Remove(card);
}

public void AddPassive(Passive passive)
{
    playerPassives.Add(passive);


}

public void RemovePassive(Passive passive)
{
    playerPassives.Remove(passive);
}

public void RemoveItem(Item item)
{
    playerItems.Remove(item);
}
public void AddItem(Item item)
{
    playerItems.Add(item);

}

}