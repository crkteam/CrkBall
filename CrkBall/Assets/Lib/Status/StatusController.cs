using System.Collections;
using System.Collections.Generic;
using IngameDebugConsole;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public BaseStatus _baseStatus;
    private JsonPlayer _jsonPlayer;

    private void Awake()
    {
        _jsonPlayer = new JsonPlayer();
        int count = 0;
        int[] ball = _jsonPlayer.getBall();
        foreach (var value in ball)
        {
            if (value == 2)
            {
                break;
            }

            count++;
        }
        status_init(count);
    }

    void status_init(int codition)
    {
        switch (codition)
        {
            case 0:
                _baseStatus = new NormalStatus();
                break;
            case 1:
                Destroy(GameObject.Find("ball"));
                Instantiate(Resources.Load("Ball/Fireball/ball"));
                GameObject.Find("ball(Clone)").gameObject.name = "ball";
                _baseStatus = new FireStatus();
                break;
            case 2:
                Destroy(GameObject.Find("ball"));
                Instantiate(Resources.Load("Ball/Thunderball/ball"));
                Instantiate(Resources.Load("Ball/Thunderball/thunder"));
                GameObject.Find("ball(Clone)").gameObject.name = "ball";
                _baseStatus = new ThunderStatus();
                break;
        }
    }
}