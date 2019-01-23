﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //scipt
    public LineController lineController;
    public BlockHolder blockHolder;
    public Result result;
    public Ads ads;
    public Game_achievement gameAchievement;
   
    // music
    public AudioSource music_death, music_main;

    public TextMesh pointUI, levelUI;

    //needToClose
    public Material invert;

    // attribute
    [SerializeField] private int round, point;

    [Header("TitleBar_image")] public GameObject TitleBar_Level;

    // Use this for initialization
    void Start()
    {
        init();
        InvokeRepeating("nextRound", 5, 5f);
        Invoke("nextRoundAnimation", 4.5f);
    }

    void init()
    {
        round = 0;
        GameObject.Find("Point").GetComponent<MeshRenderer>().sortingLayerName = "2";
        nextRound();
    }

    public void stopNextRound()
    {
        CancelInvoke("nextRound");
        InvokeRepeating("nextRound", 3, 5f);
    }

    public void setPoint(int point)
    {
        this.point += point;
        pointUI.GetComponent<TextMesh>().text = this.point.ToString();
        pointUI.transform.localScale = new Vector3(1.2f, 1.2f);
        StartCoroutine(pointScale());
    }

    public int[] getResult()
    {
        int[] result = {round, point};

        return result;
    }

    IEnumerator pointScale()
    {
        int count = 0;

        while (true)
        {
            if (count > 10)
            {
                pointUI.transform.localScale = new Vector3(0.35f, 0.35f);
                break;
            }


            pointUI.transform.localScale -= new Vector3(0.07f, 0.07f);


            count++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void nextRoundAnimation()
    {
        TitleBar_Level.GetComponent<Animator>().SetTrigger("Whirl");
    }

    void nextRound()
    {
        round++;
        levelUI.text = round.ToString();
        foreach (var gameObject in blockHolder.lines)
        {
            if (gameObject != null)
                gameObject.transform.position += new Vector3(0, -0.7f);
        }

        Invoke("nextRoundAnimation", 4.5f);
        lineController.blockHP = round;
        lineController.createLIne();
    }

    public void gameover()
    {
        gameAchievement.newhighPoint(point);
        ads.showADS();
        invert.SetFloat("_InvertColors", 0); //確保bug把它關掉
        music_main.volume = 0.1f;
        music_death.Play();
        Invoke("gameover_result", 1);
        CancelInvoke("nextRound");
    }

    private void gameover_result() // 因為要等死亡動畫先播放
    {
        result.compute();
    }
}