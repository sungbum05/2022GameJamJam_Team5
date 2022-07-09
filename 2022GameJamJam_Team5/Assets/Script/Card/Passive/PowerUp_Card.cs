using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Card : CardData
{
    private void Start()
    {
        CardBasicSetting();
    }

    public override void CardEffect()
    {
        base.CardEffect();

        InGameMgr.Player.POWER_STATE += 1;
        InGameMgr.PowerUpParticle.gameObject.SetActive(true);
        InGameMgr.PowerUpParticle.Play();
    }

    public override void CardBasicSetting()
    {
        base.CardBasicSetting();
    }
}
