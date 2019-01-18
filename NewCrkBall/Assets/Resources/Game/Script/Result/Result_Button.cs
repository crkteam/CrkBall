using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_Button : MonoBehaviour {
    private void OnMouseDown()
    {
        if (gameObject.name.Equals("Result_Home"))
        {
            SceneManager.LoadScene("Lobby");
        }
        
        if (gameObject.name.Equals("Result_Return"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
