using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject StoneB;

    public void OnFoxBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        StoneB.SetActive(true);
    }
}
