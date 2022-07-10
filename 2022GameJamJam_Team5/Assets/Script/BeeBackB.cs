using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnBeeBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        FoxB.SetActive(true);
        StoneB.SetActive(true);
    }
}
