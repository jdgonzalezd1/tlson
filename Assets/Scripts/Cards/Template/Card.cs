using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "card", menuName = "Cards/Empty Card")]
public class Card : ScriptableObject
{
    public string cardName;

    public string cardDescription;

    public Sprite splashArt;

    public int flowerCost;

    public int seedCost;

    public int waterCost;    
    
}
