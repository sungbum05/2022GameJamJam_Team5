using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;
    public GameObject RaccoonB;
    public GameObject FlowerB;

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        ButterflyB.SetActive(false);
        BeeB.SetActive(false);
        FoxB.SetActive(false);
        StoneB.SetActive(false);
        RaccoonB.SetActive(false);
        FlowerB.SetActive(false);
    }
}
