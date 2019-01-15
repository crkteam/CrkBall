using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ButtonController : MonoBehaviour {
    
    public void goGame()
    {
        SceneManager.LoadScene("Game");
    }
}
