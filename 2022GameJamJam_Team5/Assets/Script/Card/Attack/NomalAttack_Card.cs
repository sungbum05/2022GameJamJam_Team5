using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalAttack_Card : CardData
{
    private void Start()
    {
        CardBasicSetting();
    }

    public override void CardEffect()
    {
        base.CardEffect();

        // ȿ��
        InGameMgr.Monster.CURHP -=  7 * InGameMgr.Player.POWER_STATE;
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
