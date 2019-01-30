using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Init") != 1)
        {
            PlayerPrefs.SetInt("Login",0);
            PlayerPrefs.SetInt("point",0);
            PlayerPrefs.SetInt("level",0);
            PlayerPrefs.SetInt("Init",1);
            PlayerPrefs.SetInt("battle",0);
            Debug.Log("初始化");
        }
    }
    
}
