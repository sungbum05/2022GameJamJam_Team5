using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject FlowerB;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;

    public void OnFoxBackB()
    {
        Panel.SetActive(false);
        FlowerB.SetActive(true);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
    }
}
