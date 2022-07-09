using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowCard : MonoBehaviour
{
    [Header("Show카드 속성")]
    public Vector2 OriginPos = new Vector2(0, 0);

    public IEnumerator Draw()
    {
        yield return null;
        Debug.Log("Draw");

        while (true)
        {
            yield return null;

            this.gameObject.transform.DOMove(new Vector2(this.gameObject.transform.position.x, -2.5f), 0.7f);

            if(this.gameObject.transform.position.y > -2.51f)
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, -2.5f);
                break;
            }   
        }
        
        yield break;
    }

    public IEnumerator Insert()
    {
        yield return null;

        Debug.Log("Insert");

        while (true)
        {
            yield return null;

            this.gameObject.transform.DOMove(new Vector2(this.gameObject.transform.position.x, -7.0f), 0.7f);

            if (this.gameObject.transform.position.y < -6.9f)
            {
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, -7.0f);
                break;
            }
        }

        yield break;
    }
}
