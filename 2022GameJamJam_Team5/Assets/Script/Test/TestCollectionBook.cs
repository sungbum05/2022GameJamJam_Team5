using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AnimalType
{
    public string Name;
    public Sprite Img;
    public string asd;
}

public class TestCollectionBook : MonoBehaviour
{
    public List<AnimalType> animals;

    public Text NameTxt;
    public Image AnimalImg;
    public Text Animalasdasd;

    // Start is called before the first frame update
    void Start()
    {
        NameTxt.text = animals[0].Name;
        AnimalImg.sprite = animals[0].Img;
        Animalasdasd.text = animals[0].asd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
