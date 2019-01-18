using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : MonoBehaviour {
    private void OnMouseDown()
    {
        if (gameObject.name.Equals("Return"))
        {
            GameObject.Find("pause_background").SetActive(false);
            
        }

        if (gameObject.name.Equals("Exit"))
        {
            SceneManager.LoadScene("Lobby");
        }
        
        Time.timeScale = 1;
    }
}
