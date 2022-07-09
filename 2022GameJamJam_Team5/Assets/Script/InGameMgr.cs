using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMgr : MonoBehaviour
{
    [Header("플레이어 공유 속성")]
    public Player Player;
    public GameObject PassiveImgAddSpace;

    [Header("적 공유 속성")]
    public CharecterStat Monster;

    [Header("카드 공유 속성")]
    public List<CardData> CardData;

    [Header("주사위 공유 속성")]
    public int MaxDiceNumber;
    public int MinDiceNumber;
    public int RandomDiceNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
