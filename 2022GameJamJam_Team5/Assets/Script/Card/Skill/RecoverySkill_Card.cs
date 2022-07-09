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

        // È¿°ú
        InGameMgr.Player.CURHP += 7;
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
