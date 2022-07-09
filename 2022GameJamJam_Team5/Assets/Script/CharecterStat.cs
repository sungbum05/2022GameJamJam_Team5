using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Monster, Player
}


[SerializeField]
public class CharecterStat : MonoBehaviour
{
    [Header("�⺻ ����")]
    public CharacterType Type;

    //ü�� ������Ƽ
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

    //�� ������Ƽ
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

    //��ø�� ������Ƽ
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

    [Header("���� �̻�")]
    public bool IsPoison = false;
    public bool IsFaint = false;
    public bool IsBurn = false;

    [Header("ĳ���� ����")]
    [SerializeField]
    private int maxhp = 0;
    public int MAXHP
    {
        get
        {
            return maxhp;
        }
        set
        {
            maxhp = value;
        }
    }

    [SerializeField]
    private int curhp = 0;
    public int CURHP
    {
        get
        {
            return curhp;
        }
        set
        {
            curhp = value;
        }
    }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        CharacterSetting();
    }

    public virtual void CharacterSetting()
    {
        MAXHP = HP_STATE * 100;
        CURHP = MAXHP;
    }
}
