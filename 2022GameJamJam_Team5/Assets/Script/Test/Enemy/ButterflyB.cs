using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        FlowerB.SetActive(false);
        BeeB.SetActive(false);
        FoxB.SetActive(false);
        StoneB.SetActive(false);
    }
}
