using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flower_Monster : CharecterStat
{
    public override IEnumerator AttackPatton()
    {
        yield return null;

        Debug.Log("Flower");
        this.gameObject.transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.5f);
        InGameMgr.Player.CURHP -= 3 * POWER_STATE;

        yield return new WaitForSeconds(0.3f);

        this.gameObject.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.5f);
    }
}
