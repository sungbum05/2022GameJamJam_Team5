using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstorBook : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button2;

    public void OnPanel()
    {
        Panel.SetActive(true);
        Button2.SetActive(true);
    }
}
