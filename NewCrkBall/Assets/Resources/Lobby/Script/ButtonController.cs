using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private AudioSource Next,Main;
    
    public void goGame()
    {
        Main.Stop();
        Next.Play();
        
        Invoke("next",1);
    }

    void next()
    {
        SceneManager.LoadScene("Game");
    }
}
