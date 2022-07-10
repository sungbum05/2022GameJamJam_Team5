using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharecterStat
{
    bool IsSceneChange = false;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CURHP <= 0 && IsSceneChange == false)
        {
            IsSceneChange = true;
            SceneManager.LoadScene(2);
        }
    }

    public override void CharacterSetting()
    {
        base.CharacterSetting();
    }
}
