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
    [Header("�ܺ� �Ӽ�")]
    public InGameMgr InGameMgr;

    [Header("ī�� ���� �Ӽ�")]
    public bool IsCardUnlock = false;
    public CardType CardType;

    [Header("ī�� �ܺ� �Ӽ�")]
    public string CardName;
    public Sprite CardImg;
    public string CardExplanation;

    [Header("ī�� ����Ʈ �̹���")]
    public Sprite CardEffectImg;

    CardData()
    {
        Debug.Log("asd");
    }    

    public virtual void CardEffect()
    {
        
    }
}
