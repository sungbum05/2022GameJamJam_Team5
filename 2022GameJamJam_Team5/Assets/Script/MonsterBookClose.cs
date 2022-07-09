using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBookClose : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button2;

    public void OnButton2()
    {
        Panel.SetActive(false);
        Button2.SetActive(false);
    }
}
