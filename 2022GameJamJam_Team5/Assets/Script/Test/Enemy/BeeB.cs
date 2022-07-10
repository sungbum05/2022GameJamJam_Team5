using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject FlowerB;
    public GameObject FoxB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject WolfB;

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        ButterflyB.SetActive(false);
        FlowerB.SetActive(false);
        FoxB.SetActive(false);
        StoneB.SetActive(false);
        RaccoonB.SetActive(false);
        WolfB.SetActive(false);
    }
}