using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMgr : MonoBehaviour
{
    [Header("�÷��̾� ���� �Ӽ�")]
    public Player Player;
    public GameObject PassiveImgAddSpace;

    [Header("�� ���� �Ӽ�")]
    public CharecterStat Monster;

    [Header("ī�� ���� �Ӽ�")]
    public List<CardData> CardData;

    [Header("�ֻ��� ���� �Ӽ�")]
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
