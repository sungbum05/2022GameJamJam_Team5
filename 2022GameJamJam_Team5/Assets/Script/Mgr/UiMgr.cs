using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMgr : MonoBehaviour
{
    [Header("寇何 加己")]
    [SerializeField]
    InGameMgr inGameMgr;
    [SerializeField]
    CharecterStat Player;
    [SerializeField]
    Monster Monster;

    [Header("郴何 加己")]
    [SerializeField]
    Slider PlayerHpBar;
    [SerializeField]
    Slider MonsterHpBar;
    [SerializeField]
    Text ProgressTxt;
    public bool IsFirstSetting = false;

    // Start is called before the first frame update
    void Start()
    {
        FirstPlayerHpSetting();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFirstSetting == false && Monster.CurMonsterType != null)
        {
            IsFirstSetting = true;
            FirstMonsterHpSetting();
        }

        CurHpBarSetting();
    }

    public void FirstPlayerHpSetting()
    {
        PlayerHpBar.maxValue = Player.MAXHP;
        PlayerHpBar.value = Player.CURHP;

        PlayerHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {PlayerHpBar.value} / {PlayerHpBar.maxValue}";
    }

    public void FirstMonsterHpSetting()
    {
        MonsterHpBar.maxValue = Monster.CurMonsterType.MAXHP;
        MonsterHpBar.value = Monster.CurMonsterType.CURHP;

        MonsterHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {MonsterHpBar.value} / {MonsterHpBar.maxValue}";
    }

    public void CurHpBarSetting()
    {
        if (IsFirstSetting == true && Monster.CurMonsterType != null)
        {
            MonsterHpBar.value = Monster.CurMonsterType.CURHP;
            MonsterHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {MonsterHpBar.value} / {MonsterHpBar.maxValue}";
        }

        PlayerHpBar.value = Player.CURHP;
        PlayerHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {PlayerHpBar.value} / {PlayerHpBar.maxValue}";

        ProgressTxt.text = $"柳青档: {inGameMgr.StageCurNum} / {inGameMgr.StageMaxNum}";
    }
}
