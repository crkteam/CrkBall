using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ButtonController : MonoBehaviour
{
    public Image start;
    [SerializeField] private AudioSource Next, Main;
    [SerializeField] private InternetDetect InternetDetect;
    [SerializeField] private Lobby_Firebase lobbyFirebase;
    [SerializeField] private InputField Id, password;
    [SerializeField] private GameObject login, leaderboard, achievement, LoginAlert, battle, internet,accounterror;
    [SerializeField] private AsyncOperation asyncOperation;

    private void Awake()
    {
        //修改当前的FPS
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        if (!internet.GetComponent<InternetDetect>().Internetdetect())
        {
            internet.SetActive(true);
        }

        asyncOperation = SceneManager.LoadSceneAsync("Game");
        asyncOperation.allowSceneActivation = false;
    }

    public void goGame()
    {
        if (internet.GetComponent<InternetDetect>().Internetdetect())
        {
            if (start.color.a >= 1)
            {
                Main.Stop();
                Next.Play();

                Invoke("next", 1);
            }
        }
        else
        {
            internet.SetActive(true);
        }
    }

    public void close_internet()
    {
        internet.SetActive(false);
    }

    void next()
    {
        asyncOperation.allowSceneActivation = true;
    }

    public void close_Accounterror()
    {
        accounterror.SetActive(!accounterror.activeSelf);
    }
  
    public void close_battle()
    {
        battle.SetActive(false);
    }

    public void open_leaderboard()
    {
        if (InternetDetect.Internetdetect())
        {
            if (PlayerPrefs.GetInt("battle") != 0) // 這裡改
            {
                if (PlayerPrefs.GetInt("Login") != 0)
                {
                    gameObject.GetComponent<LeaderBoard>().show();
                }
                else
                {
                    login.SetActive(true);
                }
            }
            else
            {
                battle.SetActive(true);
            }
        }
    }

    public void Close_LoginAlert()
    {
        LoginAlert.SetActive(false);
    }

    public void close_leaderboard()
    {
        leaderboard.SetActive(false);
    }

    public void open_achive()
    {
        achievement.SetActive(true);
    }

    public void close_achive()
    {
        achievement.SetActive(false);
    }

    public void close_login()
    {
        login.SetActive(false);
    }

    public void login_check()
    {
        if (internet.GetComponent<InternetDetect>().Internetdetect())
        {
              lobbyFirebase.check(Id.text, password.text);
        }
        else
        {
            internet.SetActive(true);
        }
      
    }

    public void openFan()
    {
        Application.OpenURL("https://www.facebook.com/CrkTeam-1996298847156168");
    }
}