using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB : MonoBehaviour
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

    public void OnBeeB()
    {
        Panel.SetActive(true);
        FlowerB.SetActive(false);
        ButterflyB.SetActive(false);
        RaccoonB.SetActive(false);
        FalconB.SetActive(false);
        FoxB.SetActive(false);
        TreeB.SetActive(false);
        StoneB.SetActive(false);
        HedgehogB.SetActive(false);
        WolfB.SetActive(false);
    }
}