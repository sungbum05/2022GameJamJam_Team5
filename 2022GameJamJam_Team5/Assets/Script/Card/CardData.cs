using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attck, Skill ,Passive
}

[System.Serializable]
public class CardData : MonoBehaviour
{
    public string CardName;
    public CardType CardType;
    
    public virtual void CardEffect()
    {

    }
}
