using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Lobby_Controller : MonoBehaviour
{
	private JsonPlayer Json;
	private int Cash;
	public Text Cash_text;
	
	// Use this for initialization
	void Start () {
		Json = new JsonPlayer();
		Cash = Json.getcash();
		Cash_text.text = "x "+Cash;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
