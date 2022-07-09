using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DrawCard
{
    public GameObject ShowCards;
    public CardData DrawCardDatas;
}

public class InGameMgr : MonoBehaviour
{
    [Header ("매니저 자체 속성")]
    [SerializeField]
    LayerMask Card;
    [SerializeField]
    GameObject PickCard = null;

    [Header("플레이어 공유 속성")]
    public Player Player;
    public GameObject PassiveImgAddSpace;

    [Header("적 공유 속성")]
    public CharecterStat Monster;

    [Header("카드 공유 속성")]
    public List<CardData> CardDatas;
    public List<CardData> AvailableCard;

    public List<DrawCard> DrawCard;

    [Header("주사위 공유 속성")]
    public int MaxDiceNumber;
    public int MinDiceNumber;
    public int RandomDiceNumber;

    // Start is called before the first frame update
    void Start()
    {
        ReLoadCard();

        CardInfoSetting();
    }

    // Update is called once per frame
    void Update()
    {
        CardDrawShow();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < DrawCard.Count; i++)
            {
                DrawCard[i].DrawCardDatas.CardEffect();
            }
        }

    }

    void ReLoadCard()
    {
        AvailableCard.Clear();

        foreach(CardData card in CardDatas)
        {
            if(card.IsCardUnlock == true)
                AvailableCard.Add(card);
        }
    }

    void CardInfoSetting()
    {
        for (int i = 0; i < DrawCard.Count; i++)
        {
            int RandomData = Random.Range(0, AvailableCard.Count);

            DrawCard[i].DrawCardDatas = AvailableCard[RandomData];
        }
    }

    void CardDrawShow()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 20.0f, Card);

        if (hit && PickCard == null)
        {
            PickCard = hit.collider.gameObject;
            PickCard.gameObject.GetComponent<ShowCard>().IsPick = true;
        }

        else if (!hit && PickCard != null)
        {
            PickCard.gameObject.GetComponent<ShowCard>().IsPick = false;
            PickCard = null;
        }
    }
}
