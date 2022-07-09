using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject RaccoonB;
    public GameObject FalconB;
    public GameObject FoxB;
    public GameObject TreeB;
    public GameObject StoneB;
    public GameObject HedgehogB;
    public GameObject WolfB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
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
