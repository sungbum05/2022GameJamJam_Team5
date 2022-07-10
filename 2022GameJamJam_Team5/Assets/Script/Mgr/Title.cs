using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Image StartBtn;
    public GameObject TitleImg;

    private void Start()
    {
        StartCoroutine(ShowTitle());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("InGameScene");
        }
    }

    IEnumerator ShowTitle()
    {
        while (true)
        {
            yield return null;

            StartBtn.DOFade(0, 2);

            yield return new WaitForSeconds(2.0f);

            StartBtn.DOFade(1, 2);

            yield return new WaitForSeconds(2.0f);
        }
    }
}
