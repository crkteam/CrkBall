using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Listener : MonoBehaviour
{
    private int condition = 0;
    private String Id;
    public LoginAlert LoginAlert;

    public GameObject login,loginerror;

    // Update is called once per frame
    void Update()
    {
        if (condition > 0)
        {
            if (condition == 1) //登入後先展開警告視窗
            {
                LoginAlert.show();
            }

            if (condition == 3) //由警告視窗輸入3，完成登入
            {
                PlayerPrefs.SetInt("Login", 1);
                PlayerPrefs.SetInt("point", 0);
                PlayerPrefs.SetInt("lv", 0);
                PlayerPrefs.SetString("Std_ID", Id);
                login.SetActive(false);
            }

            if (condition == 2)
            {
                loginerror.SetActive(true);
            }
            init();
            gameObject.GetComponent<Login_Listener>().enabled = false;
        }
    }

    private void init()
    {
        condition = 0;
    }

    public void SetCondition(int condition)
    {
        this.condition = condition;
    }

    public void SetID(String id)
    {
        Id = id;
    }
}