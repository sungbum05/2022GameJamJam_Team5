using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject FlowerB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
        StoneB.SetActive(true);
        RaccoonB.SetActive(true);
        FlowerB.SetActive(true);
    }
}
