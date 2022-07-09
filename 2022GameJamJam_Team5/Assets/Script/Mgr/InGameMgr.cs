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
    [Header ("�Ŵ��� ��ü �Ӽ�")]
    [SerializeField]
    LayerMask Card;
    [SerializeField]
    GameObject PickCard = null;

    [Header("�÷��̾� ���� �Ӽ�")]
    public Player Player;
    public GameObject PassiveImgAddSpace;

    [Header("�� ���� �Ӽ�")]
    public CharecterStat Monster;

    [Header("ī�� ���� �Ӽ�")]
    public List<CardData> CardDatas;
    public List<CardData> AvailableCard;

    public List<DrawCard> DrawCard;

    [Header("�ֻ��� ���� �Ӽ�")]
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

    void ReLoadCard() // ��� �� ī�� �߰�
    {
        AvailableCard.Clear();

        foreach(CardData card in CardDatas)
        {
            if(card.IsCardUnlock == true)
                AvailableCard.Add(card);
        }
    }

    void CardInfoSetting() // ī�忡 ���� ����
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

    #region Dice�Լ�

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
            DiceTxt.text = $"�ֻ��� ���� �� : {CurDiceEye}";

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
        DiceTxt.text = $"�ֻ��� ���� �� : {RandomNum}";

        StopCoroutine(Corutine_SpinDice());
    }
    #endregion
}
