using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_Button : MonoBehaviour
{
    [SerializeField] private InternetDetect InternetDetect;

    [SerializeField] private GameObject InternetAlert;

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
            InternetAlert.SetActive(true);
        }
    }
}