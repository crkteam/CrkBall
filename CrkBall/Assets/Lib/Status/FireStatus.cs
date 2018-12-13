using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStatus : BaseStatus {

	public void blockStart(GameObject gameObject)
	{
		gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
	}

	public GameObject createEffect()
	{
		return null;
	}


	public void blockBeatean(GameObject gameObject)
	{
		
	}

	public void ballStart(GameObject gameObject)
	{
		
	}

	public void ballCollision(GameObject gameObject, Collision2D other)
	{
		
	}

	public void ballTrigger(GameObject gameObject, Collider2D other)
	{
		if (other.gameObject.name == "Block(Clone)")
		{
			other.gameObject.GetComponent<Block>().Beaten();
		}
	}
}
