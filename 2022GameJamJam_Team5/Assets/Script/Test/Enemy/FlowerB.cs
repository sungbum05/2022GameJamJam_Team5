using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnFlowerB()
    {
        Panel.SetActive(true);
        ButterflyB.SetActive(false);
        BeeB.SetActive(false);
        FoxB.SetActive(false);
        StoneB.SetActive(false);
    }
}
