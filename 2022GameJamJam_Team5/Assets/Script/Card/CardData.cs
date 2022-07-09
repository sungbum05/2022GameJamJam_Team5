using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attck, Skill ,Passive
}

public class CardData : MonoBehaviour
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

    public virtual void CardEffect()
    {

    }


    public virtual void CardBasicSetting()
    {
        InGameMgr = GameObject.FindObjectOfType<InGameMgr>();
    }
}
