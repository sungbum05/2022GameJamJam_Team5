using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject WolfB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
        StoneB.SetActive(true);
        RaccoonB.SetActive(true);
        WolfB.SetActive(true);
    }
}
