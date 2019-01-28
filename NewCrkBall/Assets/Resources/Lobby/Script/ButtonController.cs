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

    [SerializeField] private Lobby_Firebase lobbyFirebase;
    [SerializeField] private InputField Id, password;
    [SerializeField] private GameObject login, leaderboard, achievement;

    private void Awake()
    {
        //修改当前的FPS
        Application.targetFrameRate = 60;
    }

    public void goGame()
    {
        if (InternetDetect())
        {
            if (start.color.a >= 1)
            {
                Main.Stop();
                Next.Play();

                Invoke("next", 1);
            }
        }
    }

    void next()
    {
        SceneManager.LoadScene("Game");
    }

    public void open_leaderboard()
    {
        if (InternetDetect())
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
        lobbyFirebase.check(Id.text, password.text);
    }

    public void openFan()
    {
        Application.OpenURL("https://www.facebook.com/CrkTeam-1996298847156168");
    }

    bool InternetDetect()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("尚未開啟網路");
            return false;
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            Debug.Log("wifi");
            return true;
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            Debug.Log("行動網路");
            return true;
        }
        else
        {
            return false;
        }
    }
}