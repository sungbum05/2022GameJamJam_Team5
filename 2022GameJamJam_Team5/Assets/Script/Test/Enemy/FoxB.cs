using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FlowerB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject WolfB;

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        ButterflyB.SetActive(false);
        BeeB.SetActive(false);
        FlowerB.SetActive(false);
        StoneB.SetActive(false);
        RaccoonB.SetActive(false);
        WolfB.SetActive(false);
    }
}
