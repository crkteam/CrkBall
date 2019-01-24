using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Ads : MonoBehaviour {

	private InterstitialAd interstitial;
	// Use this for initialization
	void Start () {
		string adUnitId = "ca-app-pub-4564963026533389/8787282204";
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void showADS()
	{
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}
}
