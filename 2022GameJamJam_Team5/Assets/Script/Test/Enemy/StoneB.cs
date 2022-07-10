using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject FlowerB;

    public void OnStoneB()
    {
        Panel.SetActive(true);
        ButterflyB.SetActive(false);
        BeeB.SetActive(false);
        FoxB.SetActive(false);
        FlowerB.SetActive(false);
    }
}
