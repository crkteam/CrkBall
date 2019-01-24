using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private AudioSource audio;
    public GameObject GameControll;
    private float[] samples = new float[8192];
    private float temp;
    private float TorqueRange;
    public float Speed=2;

// Use this for initialization
    void Start()
    {
        TorqueRange = Random.Range(-180,180);
        GameControll = GameObject.Find("Game");
        Destroy(gameObject, 4f);
        audio = GameControll.GetComponent<AudioSource>();
          gameObject.GetComponent<Rigidbody2D>().AddTorque(TorqueRange);
               
    }

    // Update is called once per frame
    void Update()
    {
       audio.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        for (int i = 0; i < samples.Length; i++)
        {
            temp += samples[i] * .3f;
        }

        gameObject.transform.localScale = new Vector3(1+temp, 1+temp, gameObject.transform.localScale.z);

        temp = 0;
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a -= 0.005f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        gameObject.transform.position += Vector3.up * Time.deltaTime * Speed;
    }
}