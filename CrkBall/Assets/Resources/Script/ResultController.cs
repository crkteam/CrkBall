using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController
{
    private JsonPlayer _jsonPlayer;
    
    public ResultController()
    {
        _jsonPlayer = new JsonPlayer();
        int point = int.Parse(GameObject.Find("Cash_text").GetComponent<TextMesh>().text);
        
        
        if(_jsonPlayer.gethighPoint() < point)
            _jsonPlayer.sethighPoint(point);
    }
}
