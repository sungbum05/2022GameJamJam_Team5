using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject FlowerB;
    public GameObject RaccoonB;
    public GameObject WolfB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
        FlowerB.SetActive(true);
        RaccoonB.SetActive(true);
        WolfB.SetActive(true);
    }
}
