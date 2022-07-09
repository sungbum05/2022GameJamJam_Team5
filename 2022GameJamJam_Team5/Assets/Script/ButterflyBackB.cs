using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject BeeB;
    public GameObject RaccoonB;
    public GameObject FalconB;
    public GameObject FoxB;
    public GameObject TreeB;
    public GameObject StoneB;
    public GameObject HedgehogB;
    public GameObject WolfB;

    public void OnButterflyBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
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
