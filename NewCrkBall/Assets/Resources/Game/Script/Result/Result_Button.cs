using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_Button : MonoBehaviour
{
    [SerializeField]
    private InternetDetect InternetDetect;
    private void OnMouseDown()
    {
        if (InternetDetect.Internetdetect())
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
        else
        {
            Debug.Log("尚未建立連線，請連線上網後在開始遊戲（Result_Button）");
        }
    }
    
}
