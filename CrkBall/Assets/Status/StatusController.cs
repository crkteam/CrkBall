using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public BaseStatus _baseStatus;

    private void Awake()
    {
        status_init(1);
    }

    void status_init(int codition)
    {
        switch (codition)
        {
            case 0:
                _baseStatus = new NormalStatus();
                break;
            case 1:
                _baseStatus = new FireStatus();
                break;
            case 2:
                _baseStatus = new ThunderStatus();
                break;
        }
    }
}