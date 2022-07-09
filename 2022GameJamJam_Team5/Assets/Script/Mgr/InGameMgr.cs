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
    [Header("�Ŵ��� ��ü �Ӽ�")]
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

    [Header("�������� ����")]
    public List<CharecterStat> Stage1_Monsters;
    public List<CharecterStat> Stage2_Monsters;

    #region �÷��̾� �ֻ���
    [Header("�ֻ��� ���� �Ӽ�")]
    public GameObject DicePanel;
    public GameObject DiceSpinBtnObj;
    public GameObject DiceExitBtnObj;

    public int MaxDiceNumber;
    public int MinDiceNumber;
    public int SelectDiceNumber;

    public Image Dice;
    public Text DiceTxt;
    public Sprite BaiscDiecImg;
    public List<Sprite> DiceSpinImg;
    #endregion

    [Header("���� �Ӽ�")]
    public bool IsCardDraw = false; // ī�� ��ο찡 �����°�?
    public bool IsDiceSpin = false; // ���̽� ������ ���� ���� �������°�?
    public bool IsUseCardEffect = false; // ��� ������ ī�尡 �� ���Ǿ��°�?
    public bool IsInsertCard = false; //��� �Ұ��� ī�尡 �ٽ� ������°�?

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BattleStart());
    }

    void ReLoadCard() // ��� �� ī�� �߰�
    {
        AvailableCard.Clear();

        foreach (CardData card in CardDatas)
        {
            if (card.IsCardUnlock == true)
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

    void PlayerLoopReset() // ���� ����
    {
        foreach (DrawCard Card in DrawCard)
        {
            Card.ShowCards.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Card.ShowCards.transform.rotation = Quaternion.Euler(Vector3.zero);
            Card.ShowCards.transform.position = Card.ShowCards.transform.GetComponent<ShowCard>().OriginPos;

            Card.DrawCardDatas = null;
        }

        IsCardDraw = false;
        IsDiceSpin = false;
        IsUseCardEffect = false;
        IsInsertCard = false;

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

            yield return new WaitForSeconds(1.5f);
            IsCardDraw = true;
        }

        else if (Type == CardDarwShowType.Insert)
        {
            for (int i = DrawCard.Count - 1; SelectDiceNumber <= i; i--)
            {
                Debug.Log(i);

                StartCoroutine(DrawCard[i].ShowCards.GetComponent<ShowCard>().Insert());

                yield return new WaitForSeconds(DrawTime);
            }

            yield return new WaitForSeconds(1.5f);
            IsInsertCard = true;
        }
    }

    IEnumerator UseCardEffct()
    {
        yield return null;

        for (int i = 0; i < SelectDiceNumber; i++)
        {
            Debug.Log("Use");

            switch ((int)DrawCard[i].DrawCardDatas.CardType)
            {
                case 0:
                    Debug.Log("Attack");
                    yield return null;

                    #region ī�� ȸ��
                    Vector3 dir = Monster.gameObject.transform.position - DrawCard[i].ShowCards.transform.position;

                    // Ÿ�� �������� ȸ����
                    float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                    DrawCard[i].ShowCards.transform.rotation = Quaternion.AngleAxis(-1 * angle, Vector3.forward);
                    #endregion

                    DrawCard[i].ShowCards.transform.DOMove(Monster.transform.position, 0.7f);
                    yield return new WaitForSeconds(0.7f);

                    DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                    yield return new WaitForSeconds(0.2f);

                    DrawCard[i].DrawCardDatas.CardEffect();
                    break;

                case 1:
                    Debug.Log("Skill");
                    yield return null;

                    DrawCard[i].ShowCards.transform.DOMove(new Vector2(DrawCard[i].ShowCards.transform.position.x, -2.0f), 0.7f);
                    yield return new WaitForSeconds(0.7f);

                    DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                    yield return new WaitForSeconds(0.2f);

                    DrawCard[i].DrawCardDatas.CardEffect();
                    break;

                    break;

                case 2:
                    Debug.Log("Passive");
                    yield return null;

                    DrawCard[i].ShowCards.transform.DOMove(new Vector2(DrawCard[i].ShowCards.transform.position.x, -2.0f), 0.7f);
                    yield return new WaitForSeconds(0.7f);

                    DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                    yield return new WaitForSeconds(0.2f);

                    DrawCard[i].DrawCardDatas.CardEffect();
                    break;
            }
        }

        IsUseCardEffect = true;
    }

    #region Dice�Լ�
    public void OnOffDicePanel()
    {
        if (DicePanel.active == false)
        {
            DicePanel.SetActive(true);
        }

        else if (DicePanel.active == true)
        {
            DicePanel.SetActive(false);
            IsDiceSpin = true;
        }
    }

    public void DiceSpinBtn()
    {
        StartCoroutine(Corutine_SpinDice());
    }

    public void DiceInfoReset()
    {
        DiceSpinBtnObj.SetActive(true);
        DiceExitBtnObj.SetActive(false);

        SelectDiceNumber = 0;

        Dice.sprite = BaiscDiecImg;
        DiceTxt.text = "�ֻ��� ���� �� : ?";
    }

    IEnumerator Corutine_SpinDice()
    {
        yield return null;
        DiceSpinBtnObj.SetActive(false);

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

        SelectDiceNumber = RandomNum;
        DiceExitBtnObj.SetActive(true);

        yield break;
    }
    #endregion

    IEnumerator BattleStart()
    {
        yield return null;

        ReLoadCard();
        bool IsOneStep = false;
        bool IsTwoStep = false;
        bool IsThreeStep = false;
        bool IsFourStep = false;

        Monster = Stage1_Monsters[0];
        StartCoroutine(Monster.AttackPatton());

        while (true) // ī�� ��ο� �ܰ�
        {
            yield return null;
            if (IsOneStep == false)
            {
                IsOneStep = true;
                StartCoroutine(CardDrawShow(CardDarwShowType.Draw));
            }

            if (IsCardDraw == true)
                break;
        }

        while (true) // ���̽� ���� �ܰ�
        {
            yield return null;
            if (IsTwoStep == false)
            {
                IsTwoStep = true;
                DiceInfoReset();
                OnOffDicePanel();
            }

            if (IsDiceSpin == true)
                break;
        }

        yield return new WaitForSeconds(0.5f);

        while (true) // ��ŭ ������ ī�� ��� �ܰ� �ܰ�
        {
            yield return null;
            if (IsThreeStep == false)
            {
                IsThreeStep = true;
                StartCoroutine(UseCardEffct());
                Debug.Log("Use CardEffect");
            }

            if (IsUseCardEffect == true)
                break;
        }

        while (true) // ������ ī�� ����
        {
            yield return null;
            if (IsFourStep == false)
            {
                IsFourStep = true;
                StartCoroutine(CardDrawShow(CardDarwShowType.Insert));

                Debug.Log("Use CardEffect");
            }

            if (IsInsertCard == true)
            {
                PlayerLoopReset();
                break;
            }
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(BattleStart());
        yield break;
    }
}
