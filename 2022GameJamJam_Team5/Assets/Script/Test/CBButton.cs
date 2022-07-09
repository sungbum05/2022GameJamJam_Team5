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
    public GameObject RaccoonB;
    public GameObject FalconB;
    public GameObject FoxB;
    public GameObject TreeB;
    public GameObject StoneB;
    public GameObject HedgehogB;
    public GameObject WolfB;

    public void OnOpenB()
    {
        Base.SetActive(true);
        CloseB.SetActive(true);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        RaccoonB.SetActive(true);
        FalconB.SetActive(true);
        FoxB.SetActive(true);
        TreeB.SetActive(true);
        StoneB.SetActive(true);
        HedgehogB.SetActive(true);
        WolfB.SetActive(true);
    }
}
