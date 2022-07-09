using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnSkill_Card : CardData
{
    private void Start()
    {
        CardBasicSetting();
    }

    public override void CardEffect()
    {
        base.CardEffect();

        InGameMgr.Monster.CurMonsterType.CURHP -= 10 * InGameMgr.Player.POWER_STATE;
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
