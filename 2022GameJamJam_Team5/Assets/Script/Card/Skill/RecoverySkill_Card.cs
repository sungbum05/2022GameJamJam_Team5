using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverySkill_Card : CardData
{
    private void Start()
    {
        CardBasicSetting();
    }

    public override void CardEffect()
    {
        base.CardEffect();
        Debug.Log("2");
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
