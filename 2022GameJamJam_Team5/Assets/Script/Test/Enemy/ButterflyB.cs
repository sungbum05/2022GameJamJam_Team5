using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyB : MonoBehaviour
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

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        FlowerB.SetActive(false);
        BeeB.SetActive(false);
        RaccoonB.SetActive(false);
        FalconB.SetActive(false);
        FoxB.SetActive(false);
        TreeB.SetActive(false);
        StoneB.SetActive(false);
        HedgehogB.SetActive(false);
        WolfB.SetActive(false);
    }
}
