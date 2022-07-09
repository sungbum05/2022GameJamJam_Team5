using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attck, Skill ,Passive
}

[System.Serializable]
public class CardData
{
    [Header("외부 속성")]
    public InGameMgr InGameMgr;

    [Header("카드 내부 속성")]
    public bool IsCardUnlock = false;
    public CardType CardType;

    [Header("카드 외부 속성")]
    public string CardName;
    public Sprite CardImg;
    public string CardExplanation;

    [Header("카드 이펙트 이미지")]
    public Sprite CardEffectImg;

    CardData()
    {
        Debug.Log("asd");
    }    

    public virtual void CardEffect()
    {
        
    }
}
