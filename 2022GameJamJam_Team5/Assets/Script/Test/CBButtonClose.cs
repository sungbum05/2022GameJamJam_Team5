using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBButtonClose : MonoBehaviour
{
    public GameObject Base;
    public GameObject CloseB;

    public void OnCloseB()
    {
        Base.SetActive(false);
        CloseB.SetActive(false);
    }
}
