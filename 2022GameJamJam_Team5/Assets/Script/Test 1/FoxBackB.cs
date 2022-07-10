using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FlowerB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject WolfB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FlowerB.SetActive(true);
        StoneB.SetActive(true);
        RaccoonB.SetActive(true);
        WolfB.SetActive(true);
    }
}
