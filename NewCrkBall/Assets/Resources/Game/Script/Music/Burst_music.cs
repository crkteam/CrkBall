using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst_music : MonoBehaviour
{
    public AudioSource main;

    public void changePitch()
    {
        InvokeRepeating("pitchDown",0,0.01f);
    }

    private void pitchDown()
    {
        if (main.pitch < 0.5f)
        {
            CancelInvoke("pitchDown");
            InvokeRepeating("pitchUp",0,0.01f);
        }

        main.pitch -= 0.01f;
    }

    private void pitchUp()
    {
        main.pitch -= 0.01f;
    }
}
