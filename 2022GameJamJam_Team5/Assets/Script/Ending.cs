using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    public GameObject Pin;
    public GameObject ResultImg;
    public GameObject ExitBtn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowEnding());
    }

    IEnumerator ShowEnding()
    {
        yield return null;

        while(true)
        {
            yield return null;
            ResultImg.transform.Translate(new Vector2(-1000,0) * Time.deltaTime);

            if (ResultImg.gameObject.GetComponent<RectTransform>().anchoredPosition.x < 0)
                break;
        }

        ExitBtn.SetActive(true);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene(0);
    }
}
