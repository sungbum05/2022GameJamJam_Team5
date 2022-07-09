using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMgr : MonoBehaviour
{
    [Header("寇何 加己")]
    [SerializeField]
    CharecterStat Player;
    [SerializeField]
    CharecterStat Monster;

    [Header("郴何 加己")]
    [SerializeField]
    Slider PlayerHpBar;
    [SerializeField]
    Slider MonsterHpBar;

    // Start is called before the first frame update
    void Start()
    {
        FirstPlayerHpSetting();
        FirstMonsterHpSetting();
    }

    // Update is called once per frame
    void Update()
    {
        CurHpBarSetting();
    }

    public void FirstPlayerHpSetting()
    {
        MonsterHpBar.maxValue = Monster.MAXHP;
        MonsterHpBar.value = Monster.CURHP;

        MonsterHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {MonsterHpBar.value} / {MonsterHpBar.maxValue}";
    }

    public void FirstMonsterHpSetting()
    {
        PlayerHpBar.maxValue = Player.MAXHP;
        PlayerHpBar.value = Player.CURHP;

        PlayerHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {PlayerHpBar.value} / {PlayerHpBar.maxValue}";
    }

    public void CurHpBarSetting()
    {
        MonsterHpBar.value = Monster.CURHP;
        PlayerHpBar.value = Player.CURHP;

        MonsterHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {MonsterHpBar.value} / {MonsterHpBar.maxValue}";
        PlayerHpBar.transform.GetChild(2).GetComponent<Text>().text = $"HP: {PlayerHpBar.value} / {PlayerHpBar.maxValue}";
    }
}
