using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject RaccoonB;
    public GameObject FalconB;
    public GameObject FoxB;
    public GameObject TreeB;
    public GameObject StoneB;
    public GameObject HedgehogB;
    public GameObject WolfB;

    public void OnBeeBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        RaccoonB.SetActive(true);
        FalconB.SetActive(true);
        FoxB.SetActive(true);
        TreeB.SetActive(true);
        StoneB.SetActive(true);
        HedgehogB.SetActive(true);
        WolfB.SetActive(true);
    }
}
