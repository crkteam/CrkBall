using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Lobby_Controller : MonoBehaviour
{
	private JsonPlayer Json;
	private int highPoint;
	public Text highPoint_text;
	
	// Use this for initialization
	void Start () {
		Json = new JsonPlayer();
		highPoint = Json.gethighPoint();
		highPoint_text.text = highPoint.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
