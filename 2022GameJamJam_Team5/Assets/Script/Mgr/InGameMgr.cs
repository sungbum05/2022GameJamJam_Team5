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
    [Header("매니저 자체 속성")]
    [SerializeField]
    LayerMask Card;
    [SerializeField]
    GameObject PickCard = null;

    [Header("플레이어 공유 속성")]
    public Player Player;
    public GameObject PassiveImgAddSpace;

    [Header("적 공유 속성")]
    public Text MonsterName;
    public Monster Monster;
    public GameObject MonsterInfoPanel;

    [Header("카드 공유 속성")]
    public List<CardData> CardDatas;
    public List<CardData> AvailableCard;

    public List<DrawCard> DrawCard;

    [Header("스테이지 정보")]
    public UiMgr UiMgr;
    public List<GameObject> Stage1_Monsters;
    public List<GameObject> Stage2_Monsters;
    public int StageCnt = 1;
    public int StageMaxNum;
    public int StageCurNum;

    #region 플레이어 주사위
    [Header("주사위 공유 속성")]
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

    [Header("전투 속성")]
    public bool IsCardDraw = false; // 카드 드로우가 끝났는가?
    public bool IsDiceSpin = false; // 다이스 스핀이 끝나 수가 정해졌는가?
    public bool IsUseCardEffect = false; // 사용 가능한 카드가 다 사용되었는가?
    public bool IsInsertCard = false; //사용 불가능 카드가 다시 들었갔는가?
    public bool IsMonsterAttack = false; //몬스터가 공격을 했는가?

    [Header("보상")]
    public GameObject GiftCanvas;

    [Header("이펙트")]
    public Image MoveEffect;
    public Image PoisionEffect;
    public Image BurnEffect;
    public Image HurtEffect;

    public ParticleSystem HelingParticle;
    public ParticleSystem PowerUpParticle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveStart());
    }

    private void Update()
    {
        if (Player.CURHP <= 50)
        {
            HurtEffect.gameObject.SetActive(true);
        }

        else
        {
            HurtEffect.gameObject.SetActive(false);
        }
    }

    void ReLoadCard() // 언락 된 카드 추가
    {
        AvailableCard.Clear();

        foreach (CardData card in CardDatas)
        {
            if (card.IsCardUnlock == true)
                AvailableCard.Add(card);
        }
    }

    void CardInfoSetting() // 카드에 정보 셋팅
    {
        for (int i = 0; i < DrawCard.Count; i++)
        {
            int RandomData = Random.Range(0, AvailableCard.Count);

            DrawCard[i].DrawCardDatas = AvailableCard[RandomData];
            DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().sprite = AvailableCard[RandomData].CardImg;
            DrawCard[i].ShowCards.GetComponent<ShowCard>().CardName.text = AvailableCard[RandomData].CardName;
        }
    }

    void PlayerLoopReset() // 루프 리셋
    {
        foreach (DrawCard Card in DrawCard)
        {
            Card.ShowCards.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Card.ShowCards.GetComponent<ShowCard>().CardName.color = new Color(0, 0, 0, 1);

            Card.ShowCards.transform.rotation = Quaternion.Euler(Vector3.zero);
            Card.ShowCards.transform.position = Card.ShowCards.transform.GetComponent<ShowCard>().OriginPos;

            Card.DrawCardDatas = null;
        }

        IsCardDraw = false;
        IsDiceSpin = false;
        IsUseCardEffect = false;
        IsInsertCard = false;
        IsMonsterAttack = false;
    }

    IEnumerator CardDrawShow(CardDarwShowType Type)
    {
        yield return null;
        float DrawTime = 0.3f;

        if (Type == CardDarwShowType.Draw)
        {
            CardInfoSetting();

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

                    #region 카드 회전
                    Vector3 dir = Monster.gameObject.transform.position - DrawCard[i].ShowCards.transform.position;

                    // 타겟 방향으로 회전함
                    float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                    DrawCard[i].ShowCards.transform.rotation = Quaternion.AngleAxis(-1 * angle, Vector3.forward);
                    #endregion

                    DrawCard[i].ShowCards.transform.DOMove(Monster.transform.position, 0.7f);
                    yield return new WaitForSeconds(0.7f);

                    DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                    DrawCard[i].ShowCards.GetComponent<ShowCard>().CardName.DOFade(0, 1f);
                    yield return new WaitForSeconds(0.2f);

                    DrawCard[i].DrawCardDatas.CardEffect();
                    break;

                case 1:
                    Debug.Log("Skill");
                    yield return null;

                    DrawCard[i].ShowCards.transform.DOMove(new Vector2(DrawCard[i].ShowCards.transform.position.x, -2.0f), 0.7f);
                    yield return new WaitForSeconds(0.7f);

                    DrawCard[i].ShowCards.GetComponent<SpriteRenderer>().DOFade(0, 1f);
                    DrawCard[i].ShowCards.GetComponent<ShowCard>().CardName.DOFade(0, 1f);
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
                    DrawCard[i].ShowCards.GetComponent<ShowCard>().CardName.DOFade(0, 1f);
                    yield return new WaitForSeconds(0.2f);

                    DrawCard[i].DrawCardDatas.CardEffect();
                    break;
            }
        }

        IsUseCardEffect = true;
    }

    #region Dice함수
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
        DiceTxt.text = "주사위 눈금 수 : ?";
    }

    IEnumerator Corutine_SpinDice()
    {
        yield return null;
        DiceSpinBtnObj.SetActive(false);

        float MaxDiceSpinTime = 0.15f;
        float CurDiceSpinTime = 0.0f;

        float PlusSpinTime = 0.004f;

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

        SelectDiceNumber = RandomNum;
        DiceExitBtnObj.SetActive(true);

        yield break;
    }
    #endregion
    IEnumerator MoveStart()
    {
        yield return null;

        GameObject SpawnMonster = null;

        switch (StageCnt)
        {
            case 1:
                SpawnMonster = Instantiate(Stage1_Monsters[StageCurNum - 1], Stage1_Monsters[StageCurNum - 1].transform.position, Quaternion.identity);
                SpawnMonster.transform.SetParent(Monster.transform);

                break;

            case 2:
                SpawnMonster = Instantiate(Stage2_Monsters[StageCurNum - 1], Stage1_Monsters[StageCurNum - 1].transform.position, Quaternion.identity);
                SpawnMonster.transform.SetParent(Monster.transform);

                break;
        }

        SpawnMonster.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        SpawnMonster.GetComponent<SpriteRenderer>().DOFade(1, 1);
        yield return new WaitForSeconds(1.0f);

        MoveEffect.gameObject.SetActive(true);
        MoveEffect.DOFade(1, 2);
        yield return new WaitForSeconds(2.0f);

        Monster.CurMonsterType = SpawnMonster.GetComponent<CharecterStat>();
        MonsterName.text = Monster.CurMonsterType.Name;

        MoveEffect.DOFade(0, 2);
        yield return new WaitForSeconds(2.0f);
        MoveEffect.gameObject.SetActive(false);

        SpawnMonster.GetComponent<SpriteRenderer>().DOColor(Color.white, 1.0f);
        MonsterInfoPanel.SetActive(true);

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(BattleStart());

        yield break;
    }

    IEnumerator BattleStart()
    {
        yield return null;

        ReLoadCard();
        bool IsOneStep = false;
        bool IsTwoStep = false;
        bool IsThreeStep = false;
        bool IsFourStep = false;
        bool IsFiveStep = false;

        while (true) // 카드 드로우 단계
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

        while (true) // 다이스 스핀 단계
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

        while (true) // 눈큼 수량의 카드 사용 단계 단계
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

        while (true) // 나머지 카드 정리
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

        yield return new WaitForSeconds(0.2f);

        while (true) // 몬스터 공격
        {
            yield return null;

            if (Monster.CurMonsterType.CURHP > 0)
            {
                if (IsFiveStep == false)
                {
                    IsFiveStep = true;
                    StartCoroutine(Monster.CurMonsterType.AttackPatton());
                    yield return new WaitForSeconds(0.7f);

                    IsMonsterAttack = true;

                    Debug.Log("AttackMonster");
                }

                if (IsMonsterAttack == true)
                {
                    break;
                }
            }

            else if (Monster.CurMonsterType.CURHP <= 0)
            {
                Debug.Log("Die");

                if (IsFiveStep == false)
                {
                    IsFiveStep = true;
                    Monster.CurMonsterType.gameObject.GetComponent<SpriteRenderer>().DOFade(0, 1);

                    Monster.CurMonsterType = null;
                    MonsterInfoPanel.SetActive(false);

                    yield return new WaitForSeconds(1.0f);
                    IsMonsterAttack = true;
                }

                if (IsMonsterAttack == true)
                {
                    GiftCanvas.SetActive(true);
                    yield break;
                }
            }
        }

        Debug.Log("BattleContinue");

        yield return new WaitForSeconds(0.2f);

        PlayerLoopReset();

        StartCoroutine(BattleStart());
        yield break;
    }

    public void SelectMaxHpUP()
    {
        Player.HP_STATE += 1;

        Player.CharacterSetting();

        UiMgr.IsFirstSetting = false;
        UiMgr.FirstPlayerHpSetting();

        GiftCanvas.SetActive(false);

        StageCurNum++;

        if (StageCurNum > StageMaxNum)
        {
            StageCnt++;
            StageCurNum = 1;
        }

        StartCoroutine(MoveStart());
    }

    public void SelectPowerUp()
    {
        Player.POWER_STATE += 1;

        UiMgr.IsFirstSetting = false;

        GiftCanvas.SetActive(false);

        StageCurNum++;

        if (StageCurNum > StageMaxNum)
        {
            StageCnt++;
            StageCurNum = 1;
        }

        StartCoroutine(MoveStart());
    }
}
