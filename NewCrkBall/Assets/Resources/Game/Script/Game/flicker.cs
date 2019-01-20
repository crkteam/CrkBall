using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    private AudioSource audio;
    public GameObject GameControll;
    private float[] samples = new float[8192];

    private float temp;

// Use this for initialization
    void Start()
    {
        GameControll = GameObject.Find("Game");
        Destroy(gameObject, 5f);
        audio = GameControll.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        for (int i = 0; i < samples.Length; i++)
        {
            temp += samples[i] * .3f;
        }

        gameObject.transform.localScale = new Vector3(temp, temp, gameObject.transform.localScale.z);

        temp = 0;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a -= 0.005f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.transform.position += Vector3.up * Time.deltaTime*1.5f;
    }
}   