using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Monster, Player
}


[SerializeField]
public class CharecterStat : MonoBehaviour
{
    [Header("기본 스탯")]
    public CharacterType Type;

    //체력 프로퍼티
    [SerializeField]
    private int hp_state = 1;
    public int HP_STATE
    {
        get
        {
            return hp_state;
        }
        set
        {
            hp_state = value;
        }
    }

    //힘 프로퍼티
    [SerializeField]
    private int power_state = 1;
    public int POWER_STATE
    {
        get
        {
            return power_state;
        }
        set
        {
            power_state = value;
        }
    }

    //민첩성 프로퍼티
    [SerializeField]
    private int agility_state = 1;
    public int AGILITY_STATE
    {
        get
        {
            return agility_state;
        }
        set
        {
            agility_state = value;
        }
    }

    [Header("상태 이상")]
    public bool IsPoison = false;
    public bool IsFaint = false;
    public bool IsBurn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
