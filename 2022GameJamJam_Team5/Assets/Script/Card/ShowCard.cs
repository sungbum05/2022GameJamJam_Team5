using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCard : CardData
{
    [Header("Show카드 속성")]
    public bool IsPick = false;
    [SerializeField]
    float PickPos = -2.0f;
    [SerializeField]
    float UnPickPos = -2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPick)
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, PickPos);
        }

        else
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, UnPickPos);
        }
    }
}
