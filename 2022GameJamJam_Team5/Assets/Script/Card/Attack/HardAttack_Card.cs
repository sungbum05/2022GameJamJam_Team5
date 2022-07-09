using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardAttack_Card : CardData
{
    private void Start()
    {
        CardBasicSetting();
    }

    public override void CardEffect()
    {
        base.CardEffect();

        InGameMgr.Monster.CURHP -= 10 * InGameMgr.Player.POWER_STATE;
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
