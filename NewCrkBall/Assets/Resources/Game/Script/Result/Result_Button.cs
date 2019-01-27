using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_Button : MonoBehaviour {
    private void OnMouseDown()
    {
        if (InternetDetect())
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
    bool InternetDetect()
    {
        if(Application.internetReachability==NetworkReachability.NotReachable)
        {
            Debug.Log("尚未開啟網路");
            return false;
        }
        else if(Application.internetReachability==NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            Debug.Log("wifi");
            return true;
        }
        else if(Application.internetReachability==NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            Debug.Log("行動網路");
            return true;
        }
        else
        {
            return false;
        }
    }
}
