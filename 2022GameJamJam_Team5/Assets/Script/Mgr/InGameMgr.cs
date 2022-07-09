using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum CardDarwShowType
{
    Draw, Insert
}

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
    public int SelectDiceNumber;

    public Image Dice;
    public Text DiceTxt;
    public Sprite BaiscDiecImg;
    public List<Sprite> DiceSpinImg;


    // Start is called before the first frame update
    void Start()
    {
        ReLoadCard();

        StartCoroutine(CardDrawShow(CardDarwShowType.Draw));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < DrawCard.Count; i++)
            {
                DrawCard[i].DrawCardDatas.CardEffect();
            }
        }

    }

    void ReLoadCard() // 언락 된 카드 추가
    {
        AvailableCard.Clear();

        foreach(CardData card in CardDatas)
        {
            if(card.IsCardUnlock == true)
                AvailableCard.Add(card);
        }
    }

    void CardInfoSetting() // 카드에 정보 셋팅
    {
        for (int i = 0; i < DrawCard.Count; i++)
        {
            int RandomData = Random.Range(0, AvailableCard.Count);

            DrawCard[i].DrawCardDatas = AvailableCard[RandomData];
        }
    }

    IEnumerator CardDrawShow(CardDarwShowType Type) 
    {
        yield return null;
        float DrawTime = 0.3f;

        CardInfoSetting();

        if (Type == CardDarwShowType.Draw)
        {
            for (int i = 0; i < DrawCard.Count; i++)
            {
                StartCoroutine(DrawCard[i].ShowCards.GetComponent<ShowCard>().Draw());

                yield return new WaitForSeconds(DrawTime);
            }
        }

        else if(Type == CardDarwShowType.Insert)
        {
            for (int i = DrawCard.Count - 1; SelectDiceNumber <= i; i--)
            {
                Debug.Log(i);

                StartCoroutine(DrawCard[i].ShowCards.GetComponent<ShowCard>().Insert());

                yield return new WaitForSeconds(DrawTime);
            }
        }
    }

    #region Dice함수

    public void DiceSpinBtn()
    {
        StartCoroutine(Corutine_SpinDice());
    }

    IEnumerator Corutine_SpinDice()
    {
        yield return null;
        float MaxDiceSpinTime = 0.15f;
        float CurDiceSpinTime = 0.0f;

        float PlusSpinTime = 0.0025f;

        int CurDiceEye = 0;

        while (true)
        {
            Debug.Log("asdasd");

            if (CurDiceEye >= DiceSpinImg.Count)
                CurDiceEye = 0;

            Debug.Log(CurDiceEye);

            Dice.sprite = DiceSpinImg[CurDiceEye];
            DiceTxt.text = $"주사위 눈금 수 : {CurDiceEye}";

            yield return new WaitForSeconds(CurDiceSpinTime);

            CurDiceSpinTime += PlusSpinTime;
            //PlusSpinTime += Time.deltaTime;
            //Debug.Log(CurDiceSpinTime);
            
            CurDiceEye++;

            if (CurDiceSpinTime > MaxDiceSpinTime || Input.GetMouseButtonDown(0))
                break;
        }

        int RandomNum = Random.Range(0, DiceSpinImg.Count);
        Dice.sprite = DiceSpinImg[RandomNum];
        DiceTxt.text = $"주사위 눈금 수 : {RandomNum}";

        StopCoroutine(Corutine_SpinDice());
    }
    #endregion
}
