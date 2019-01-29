using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool Internetdetect()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			Debug.Log("尚未開啟網路");
			return false;
		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
		{
			Debug.Log("wifi");
			return true;
		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
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
