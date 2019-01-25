using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ButtonController : MonoBehaviour
{
    public Image start;
    [SerializeField]
    private AudioSource Next,Main;

    [SerializeField] private GameObject achievement;

    private void Awake()
    {
        //修改当前的FPS
        Application.targetFrameRate = 60;
    }

    public void goGame()
    {
        if (start.color.a >= 1)
        {
            Main.Stop();
            Next.Play();
        
            Invoke("next",1);
        }

    }

    void next()
    {
        SceneManager.LoadScene("Game");
    }

    public void open_achive()
    {
        achievement.SetActive(true);
    }
    
    public void close_achive()
    {
        achievement.SetActive(false);
    }
   
}

