using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBButton : MonoBehaviour
{
    public GameObject Base;
    public GameObject CloseB;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnOpenB()
    {
        Base.SetActive(true);
        CloseB.SetActive(true);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
        StoneB.SetActive(true);
    }
}
