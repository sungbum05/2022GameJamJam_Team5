using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnBeeB()
    {
        Panel.SetActive(true);
        FlowerB.SetActive(false);
        ButterflyB.SetActive(false);
        FoxB.SetActive(false);
        StoneB.SetActive(false);
    }
}