using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [Header("Ball_Attack")] public int ball_attack = 1;
    [Header("Block_Lv")] public int Lv;

    private bool game;
    public GameObject GameObject;
    public TextMesh Lv_Text, Cash;
    public GameObject death_background;
    private GameObject effect;
    private StatusController statusController;
    private ResultController resultController;
    public int cash;

    // Use this for initialization
    void Start()
    {
        statusController = GameObject.Find("Main Camera").GetComponent<StatusController>();
        effect = statusController._baseStatus.createEffect();

        if (effect != null)
        {
            GameObject effectGameObject = Instantiate(effect);
        }

        game = true;
        Lv = 0;
        InvokeRepeating("drop", 0, 5f);
    }


    public void setAttack(int value)
    {
        ball_attack = value;
        foreach (var block in GameObject.FindGameObjectsWithTag("Block"))
        {
            block.GetComponent<Block>().ball_attack = value;
        }
    }

    void drop()
    {
        Lv++;
        Lv_Text.text = "Lv" + Lv;
        if (GameObject.FindWithTag("Line") != null)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Line");

            StartCoroutine(droping(gameObjects));
        }

        Instantiate(GameObject, GameObject.transform.position, GameObject.transform.rotation);
    }

    public void death()
    {
        resultController = new ResultController();
        death_background.SetActive(true);

        CancelInvoke("drop");
        GameObject.Find("ball").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (game)
        {
            if (GameObject.FindGameObjectWithTag("Line") != null)
            {
                if (GameObject.FindGameObjectWithTag("Line").transform.position.y < -3.5)
                {
                    death();
                    game = false;
                }
            }
        }

        Cash.text = cash.ToString();
    }

    public void addCash(int cash)
    {
        this.cash += cash;
        Cash.text = this.cash.ToString();
        StartCoroutine(textchang());
    }

    IEnumerator textchang()
    {
        int count = 0;
        Cash.transform.localScale = new Vector3(0.57f, 0.57f);
        while (count < 10)
        {
            count++;
            Cash.transform.localScale -= new Vector3(0.05f, 0.05f);
            yield return new WaitForSeconds(0.01f);
        }

        Cash.transform.localScale = new Vector3(0.07f, 0.07f);
    }

    IEnumerator droping(GameObject[] gameObjects)
    {
        int count = 0;

        while (count < 10)
        {
            count++;
            foreach (var VARIABLE in gameObjects)
            {
                Vector3 now = VARIABLE.transform.position;
                now.y -= 0.07f;
                VARIABLE.transform.position = now;
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}