using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flower_Monster : CharecterStat
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator AttackPatton()
    {
        yield return null;

        Debug.Log("Flower");
        this.gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
    }
}
