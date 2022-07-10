using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBackB : MonoBehaviour
{
    public GameObject Panel;
    public GameObject ButterflyB;
    public GameObject BeeB;
    public GameObject FoxB;
    public GameObject StoneB;

    public void OnFlowerBackB()
    {
        Panel.SetActive(false);
        ButterflyB.SetActive(true);
        BeeB.SetActive(true);
        FoxB.SetActive(true);
        StoneB.SetActive(true);
    }
}
